using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserSystem.Models;

namespace UserSystem.Controllers
{
    public class ProfileController : Controller
    {
        // calling the UserSystemContext for all actions in that controller
        UserSystemContext context = new UserSystemContext();
        [HttpPost]
        public IActionResult Upload()
        {
            // checks if the user is logged into his account when they try to update their avatar, to prevent a potential error
            if (User.Identity.IsAuthenticated)
            {
                var msLength = 0;
                var fileName = "";
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                UserAvatar img = new UserAvatar();
                MemoryStream ms = new MemoryStream();
                foreach (var file in Request.Form.Files)
                {
                    file.CopyTo(ms);
                    // this variable will count the amount of bytes this file has
                    msLength = ((int)ms.Length);
                    fileName = file.FileName;

                    // to close the data stream and release resources that were used by stream
                    ms.Close();
                    ms.Dispose();  
                }

                if (msLength < 1048576)
                {
                    string[] allowedExtensions = { "JPG", "JPEG", "PNG", "GIF" };
                    string ext = fileName.Split('.').Last().ToUpper();
                    var checkExt = Array.Exists(allowedExtensions, x => x == ext);
                    if (checkExt)
                    {
                        // this one is RemoveRange in order to delete all duplicates in case if they existed due to any error
                        var oldAvatarSelectAll = context.UserAvatars.Where(x => x.UserID == userID).DefaultIfEmpty();
                        // this one is to check if any avatar for this user exists
                        var oldAvatarCheck = context.UserAvatars.Where(x => x.UserID == userID).FirstOrDefault();
                        if (oldAvatarCheck != null)
                        {
                            // removing the old avatar (if it exists) before saving the new one
                            context.RemoveRange(oldAvatarSelectAll);
                        }

                        //saving the new avatar
                        context.UserAvatars.Add(img);
                        img.AvatarData = ms.ToArray();
                        img.UserID = userID;
                        context.SaveChanges();
                    }
                    // multiple returns for multiple cases: error or success
                    else
                    {
                        return RedirectToAction("Manage", "Account", new { area = "Identity" }, "?errorMessage=Please choose a valid image type.");
                    }

                }
                else
                {
                    return RedirectToAction("Manage", "Account", new { area = "Identity" }, "?errorMessage=Maximum allowed image size is 1MB.");
                }
            }
            return RedirectToAction("Manage", "Account", new { area = "Identity" });
        }

        [HttpPost]
        public IActionResult Remove()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // this one is RemoveRange in order to delete all duplicates in case if they existed due to any error
            var oldAvatarSelectAll = context.UserAvatars.Where(x => x.UserID == userID).DefaultIfEmpty();
            // this one is to check if any avatar for this user exists
            var oldAvatarCheck = context.UserAvatars.Where(x => x.UserID == userID).FirstOrDefault();
            if (oldAvatarCheck != null)
            {
                // delete the avatars if they do exist
                context.RemoveRange(oldAvatarSelectAll);
                context.SaveChanges();
            }

            return RedirectToAction("Manage", "Account", new { area = "Identity" });
        }
    }
}
