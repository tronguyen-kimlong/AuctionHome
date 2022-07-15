using System.Collections.Generic;

namespace AuctionHome.Library
{
    public class ConvertStringAndList
    {
		public List<string> stringToList(string kk) // are you cheching null;
		{
			var arrL = new List<string>();
			string newst = "";
			if(kk != null || kk != "")
            {
				for (int i = 0; i < kk.Length; i++)
				{

					if (kk[i] == ',')
					{
						arrL.Add(newst);
						newst = "";
					}
					else
					{
						newst += kk[i];
					}
					if (i == kk.Length - 1)
					{
						arrL.Add(newst);
					}
				}
				
            }
			return arrL;
		}

		public string listToString(List<string> listItem)
		{

			string ss = "";
			for (int i = 0; i < listItem.Count; i++)
			{
				if (i == 0)
					ss += listItem[0];
				else
					ss += "," + (string)listItem[i];
			}
			return ss;
		}

		public bool checkingAlreadyExistsItem(List<string> listItem, string newItem)
        {
			foreach(string item in listItem)
            {
				if(item == newItem)
                {
					return true;
                }
            }
			return false;
        }
	}
}
