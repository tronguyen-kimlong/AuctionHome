using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHome.Data;
using AuctionHome.Models;
using AuctionHome.Interfaces;
using AuctionHome.Library;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace AuctionHome.Controllers
{
   
    public class ItemsController : Controller
    {
       
        private readonly IItem itemInterface;
        private readonly ICategory categoryInterface;
        private readonly IUser userInterface;
        private readonly IMyAuctioning myAuctioningInterface;
        private readonly IListAuctioning listAuctioningInterface;

        public ItemsController( IItem iItem, ICategory category, IUser user, IMyAuctioning myAuctioning, IListAuctioning listAuctioning)
        {
           
            itemInterface = iItem;
            categoryInterface = category;
            userInterface = user;
            myAuctioningInterface = myAuctioning;
            listAuctioningInterface = listAuctioning;
        }

        // GET: Items
        public async Task<IActionResult> Index(int ? PageIndex,
           
            bool isAccept = true,
            bool auction = true,
            bool isSold = false,
            bool isPaid = false
            )
        {

            
            if(PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;  
            }
            var getItemAll = await itemInterface.GetPagingItem((int)PageIndex, 
                isAccept, 
                auction, 
                isSold, 
                isPaid);
            
            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";
            
            return View(getItemAll.Items);
            
        }
       
         
        [Authorize]
        public async Task<IActionResult> MyItems(int? PageIndex)
        {
            if (PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;
            }
            string username = getUserClaim();
            var getItemAll = await itemInterface.MyItems((int)PageIndex, username);

            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";

            return View("MyItems",getItemAll.Items);
        }
        [Authorize]
        public async Task<IActionResult> NotAccept(int? PageIndex)
        {
            if (PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;
            }
            string username = getUserClaim();
            var getItemAll = await itemInterface.MyItemsIsAccept((int)PageIndex, username, false);

            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";

            return View("MyItems", getItemAll.Items);
        }
        [Authorize]
        public async Task<IActionResult> Sold(int? PageIndex)
        {
            if (PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;
            }
            string username = getUserClaim();
            var getItemAll = await itemInterface.MyItemsIsSold((int)PageIndex, username, true);

            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";

            return View("MyItems", getItemAll.Items);
        }
        [Authorize]
        public async Task<IActionResult> Paid(int? PageIndex)
        {
            if (PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;
            }
            string username = getUserClaim();
            var getItemAll = await itemInterface.MyItemsIsPaid((int)PageIndex, username, true);

            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";

            return View("MyItems", getItemAll.Items);
        }
        [Authorize]
        public async Task<IActionResult> ReadyAuction(int? PageIndex)
        {
            if (PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;
            }
            string username = getUserClaim();
            var getItemAll = await itemInterface.MyItemsReadyAuction((int)PageIndex, username, true);

            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";

            return View("MyItems", getItemAll.Items);
        }
        [Authorize]
        public async Task<IActionResult> Auction(int? PageIndex)
        {
            if (PageIndex == null || PageIndex <= 0)
            {
                PageIndex = 0;
            }
            string username = getUserClaim();
            var getItemAll = await itemInterface.MyItemsIsAuction((int)PageIndex, username, true);

            ViewBag.PageIndex = getItemAll.PageIndex;
            ViewBag.PageTotal = getItemAll.PageTotal;
            ViewBag.Controller = "Items";
            ViewBag.Action = "Index";
            ViewBag.Route = "PageIndex";

            return View("MyItems", getItemAll.Items);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int id)
        {
            int idItem = id;
            if (idItem == null)
            {
                return NotFound();
            }

            
            var item = await itemInterface.getByID(idItem);
            if (item == null)
            {
                return NotFound();
            }

            // get ListAuctioning;
            // get MyAuctiong into foreach;
            // get list username are auctioning;
            // show the list

            //steps 1;
            var listAucCurrent = await listAuctioningInterface.getByID(idItem);// posible null;
            var arrLAuc = new List<string>();
            if (listAucCurrent != null)
            {
                arrLAuc = new ConvertStringAndList()
                                .stringToList(listAucCurrent.ArrayIdMyAuctioningString);
            }
             
            //steps 2;
            List<string> arrayUsers = new List<string>();
            foreach(var idMyAuc in arrLAuc)
            {
                var myAuctioning = await myAuctioningInterface.getByID(Int32.Parse(idMyAuc.ToString()));
                // steps 3;
                var getUsername = myAuctioning.IdUser;
                // steps 4; save the users;
                arrayUsers.Add(getUsername);
            }
            ViewBag.UserList = arrayUsers;
            return View(item);

        }

        // get Items/AddOrEdit
        //[Authorize]
        [Authorize]
        public async Task<IActionResult> AddOrEdit(int ?id)
        {
          

            ViewData["IdCategory"] = new SelectList(await categoryInterface.getAll(), "Id", "Id");
            ViewData["IdUser"] = new SelectList(User.Claims, "Value", "Value");
            
            if (id == null || id == 0)
            {
                return View();
            }

            var item = await itemInterface.getByID((int)id);

            string valueSesstion = null;
            if(item.ImageItems != null)
            {
                //valueSesstion = Encoding.Default.GetString(item.ImageItems);
                //valueSesstion = Convert.ToBase64String(item.ImageItems);
                //HttpContext.Session.SetString("SessionImage", valueSesstion);
            }
           
            return View( item);
        }
        // postitems
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddOrEdit(IFormFile ?ImageItems,int ?id,  Item item )
        {
            ViewData["IdCategory"] = new SelectList(await categoryInterface.getAll(), "Id", "Id", item.IdCategory);
            ViewData["IdUser"] = new SelectList(await userInterface.getAll(), "Username", "Username", item.IdUser);
          

            //if (await itemInterface.isMyItem(getUserClaim(), item.Id)) 
            //{
            //    ViewData["Error"] = "You don't permition to edit this items. Because You are not owner of this";
            //    return View(item); 
            //}

            if (ModelState.IsValid)
            {
                if (ImageItems != null)
                {
                    // handle images
                    item.ImageItems = new HandleFormImage().getImage(ImageItems);

                }
                
                if (id != item.Id && id != null)
                {
                    try
                    {
                       
                        await itemInterface.create(item);
                        return Ok("successItem");

                    } catch (Exception ex)
                    {
                        throw;
                    }
                }else
                {
                    try
                    {

                        if (ImageItems == null)
                        {
                            await itemInterface.updateWithoutImage(item);
                        }

                       
                        //await itemInterface.updateDescription(item);
                        await itemInterface.update(item);
                        
                        return Ok("successItem");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (itemInterface.getByID(item.Id) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                
                
            }
            
            
            return View(item);
        }
      
      

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await itemInterface.getByID(id);
            if(item != null)
            {
                try
                {
                   
                    if (await itemInterface.delete(item))
                        return Ok("successDelete");
                    return BadRequest("wrrong");
                } catch
                {
                    throw;
                }
               
            }
            return BadRequest("wrongDelete");
        }


        private string getUserClaim()
        {
            
            foreach (var claim in User.Claims)
            {
                var claimType = claim.Type;
                if (claimType == "username") return claim.Value;
               
            }
            return null;
        }
        
    }
}
