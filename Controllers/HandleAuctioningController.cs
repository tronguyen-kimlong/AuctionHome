using AuctionHome.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuctionHome.Controllers
{
    public class HandleAuctioningController : Controller
    {
        private readonly IItem itemInterface;
        private readonly IListAuctioning listAuctioningInterface;
        private readonly IMyAuctioning myAuctioningInterface;

        private string getUserClaim()
        {

            foreach (var claim in User.Claims)
            {
                var claimType = claim.Type;
                if (claimType == "username") return claim.Value;

            }
            return null;
        }
        public HandleAuctioningController(IItem item
            , IListAuctioning listAuctioning
            , IMyAuctioning myAuctioning
            )
        {
            itemInterface = item;
            this.listAuctioningInterface = listAuctioning;
            this.myAuctioningInterface = myAuctioning;
        }

        [HttpPost]
        public  async Task<IActionResult> AddOrEdit(int myMoney)
        {
            //int? idItem, int? myMoney
            return Ok(myMoney);
            //if(idItem > 0)
            //{
            //    string idItemAndUser = idItem + getUserClaim();
            //    var item = await itemInterface.getByID(idItem); // not null
            //    var listAuctioning = await listAuctioningInterface.getByID(idItem); // can null
            //    var myAuctioning = await myAuctioningInterface.getByID(idItemAndUser); // can null
            //    if(myMoney > item.PriceAuction)
            //    {
            //        // do something
            //    }
            //}
            //return RedirectToAction("profile", "person");
            
        }
    }
}
