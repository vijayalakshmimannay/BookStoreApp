using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IWishListRL
    {
        public WishListModel AddWishList(WishListModel wish, int UserId);
    }
}
