using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNWeb_BTL_BanLaNha.Models;

namespace CNWeb_BTL_BanLaNha.Views.Classs
{
    public class CartItem
    {
        public spMoi sp { get; set; }
        public int Quantity { set; get; }
        public float ThanhTien
        {
            get
            {
                return (float)sp.GiaSP.Value*(1-float.Parse(sp.PhanTramKM)) * (float)Quantity;
            }
        } 
    }
    public class Cart
    {
        public readonly List<CartItem> cart = new List<CartItem>();
        public List<CartItem> getCart
        {
            get { return cart; }
        }
        public void AddItem(spMoi s, int sl)
        {
            CartItem line = cart.Where(p => p.sp.MaSP == s.MaSP).FirstOrDefault();
            if (line == null)
            {
                cart.Add(new CartItem
                {
                    sp = s,
                    Quantity = sl
                });
            }
            else
            {
                line.Quantity += sl;
                if (line.Quantity <= 0)
                {
                    cart.RemoveAll(l => l.sp.MaSP == s.MaSP);
                }
            }
        }
        public void UpdateItem(spMoi s, int sl)
        {
            CartItem line = cart.Where(p => p.sp.MaSP == s.MaSP).FirstOrDefault();
            if (line != null)
            {
                if (sl > 0)
                {
                    line.Quantity = sl;
                }
                else
                {
                    cart.RemoveAll(l => l.sp.MaSP == s.MaSP);
                }
            }
        }
        public void RemoveLine(spMoi s)
        {
            cart.RemoveAll(l => l.sp.MaSP == s.MaSP);
        }
        public float? ComputeTotalValue()
        {
            return cart.Sum(e => e.ThanhTien);

        }
        public int? ComputeTotalProduct()
        {
            return cart.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            cart.Clear();
        }
    }
}