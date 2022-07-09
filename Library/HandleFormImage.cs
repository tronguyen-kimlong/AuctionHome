using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace AuctionHome.Library
{
    public class HandleFormImage
    {
        public byte[] getImage(IFormFile formImage)
        {
            byte[] image = null;
            if (formImage != null)

            {
                if (formImage.Length > 0)

                //Convert Image to byte and save to database

                {

                    byte[] p1 = null;
                    using (var fs1 = formImage.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    image = p1;
                    return image;

                }
            }
            return image;
        }
        public string getUrlImage(byte[] dataImage)
        {
            if(dataImage == null) return null;
            string imreBase64Data = Convert.ToBase64String(dataImage);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            
           // Console.WriteLine(imgDataURL);

            return imgDataURL;
        }
    }
}
