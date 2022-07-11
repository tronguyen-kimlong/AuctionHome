using AuctionHome.Interfaces;
using System.Threading.Tasks;

namespace AuctionHome.Library
{
    public class MyMoney
    {
        private readonly IMyAuctioning myAuctioningInterface;

        public MyMoney(IMyAuctioning myAuctioning)
        {
            myAuctioningInterface = myAuctioning;
        }
        public async Task<int> getMoney(int idItem, string idUser)
        {
           var newitem = await myAuctioningInterface.getByIdItemAndIdUser(idItem, idUser);
            if (newitem == null) return 0;
            return (int)newitem.Cost;
        }
    }
}
