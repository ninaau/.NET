using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Ass2NET.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Ass2NET.Models.ViewModels;
using System.Linq;
using Ass2NET.Models;

namespace Ass2NET.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly SchoolCommunityContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string containerName = "advertisementimages";

        public AdvertisementsController(SchoolCommunityContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }


        public async Task<IActionResult> Index(string ID)
        {

            if (ID != null)
            {
                ViewModel communityViewModel = new ViewModel();

                communityViewModel.communities = await _context.Communities
                                                      .Include(i => i.CommunityAdvertisements)
                                                           .ThenInclude(i => i.Advertisement).ToListAsync();

                ViewData["CommunityId"] = ID;
                communityViewModel.CommunityAdvertisements = communityViewModel.communities.Where(i => i.CommunityId == ID).Single().CommunityAdvertisements;



                return View(communityViewModel);

            }
            return View("Error");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, IFormFile file)
        {
            BlobContainerClient containerClient;

            try
            {
                containerClient = await _blobServiceClient.CreateBlobContainerAsync(containerName);
                containerClient.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            }
            catch (RequestFailedException)
            {
                containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            }

            try
            {
                var blockBlob = containerClient.GetBlobClient(file.FileName);
                if (await blockBlob.ExistsAsync())
                {
                    await blockBlob.DeleteAsync();
                }

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);


                    memoryStream.Position = 0;

                    await blockBlob.UploadAsync(memoryStream);
                    memoryStream.Close();
                }


                var image = new Advertisement();
                image.imageUrl = blockBlob.Uri.AbsoluteUri;
                image.FileName = file.FileName;

                _context.Advertisements.Add(image);

                await _context.SaveChangesAsync();

                CommunityAdvertisement cs = new CommunityAdvertisement();
                cs.AdvertisementsId = image.AdvertisementId;
                cs.CommunityId = id;
                _context.CommunityAdvertisements.Add(cs);

                await _context.SaveChangesAsync();

            }
            catch (RequestFailedException)
            {
                View("Error");
            }

            return RedirectToAction("Index", new { id });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Advertisements
                .FirstOrDefaultAsync(m => m.AdvertisementId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Advertisements.FindAsync(id);
            var communityId = _context.CommunityAdvertisements.Where(i => i.AdvertisementsId == id).Single().CommunityId;

            BlobContainerClient containerClient;

            try
            {
                containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            }
            catch (RequestFailedException)
            {
                return View("Error");
            }

            try
            {
                var blockBlob = containerClient.GetBlobClient(image.FileName);
                if (await blockBlob.ExistsAsync())
                {
                    await blockBlob.DeleteAsync();
                }

                _context.Advertisements.Remove(image);
                await _context.SaveChangesAsync();

            }
            catch (RequestFailedException)
            {
                return View("Error");
            }

            return RedirectToAction("Index", new { id = communityId });
        }
    }
}
