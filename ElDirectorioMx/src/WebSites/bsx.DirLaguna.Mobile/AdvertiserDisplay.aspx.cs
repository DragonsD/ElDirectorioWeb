using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Mobile.Code;

namespace bsx.DirLaguna.Mobile
{
    public partial class AdvertiserDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                string path =this.Request.RawUrl;
                string content = "Categorias";

                if (path.Contains(QueryKeys.Keywords))
                {
                    if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.Keywords].ToString()))
                        content = string.Format("Buscar - {0}", this.Request.QueryString[QueryKeys.Keywords].ToString());
                }
                else
                    content = string.Format("Negocios con Categoria que comienza con {0}", this.AdvertiserDisplayControl1.RequestedLetter);

                this.Page.Title = string.Format("ElDirectorio.mx - {0}", content);

                if (this.AdvertiserDisplayControl1.CityId != -1)
                {
                    this.BackUpHyperLink.NavigateUrl = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.Default), QueryKeys.Keywords, this.AdvertiserDisplayControl1.Keywords);
                    this.BackBottomHyperLink.NavigateUrl = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.Default), QueryKeys.Keywords, this.AdvertiserDisplayControl1.Keywords);
                }
                else
                {
                    this.BackUpHyperLink.NavigateUrl = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CategoryDisplay), QueryKeys.CategoryLetter, this.AdvertiserDisplayControl1.RequestedLetter);
                    this.BackBottomHyperLink.NavigateUrl = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CategoryDisplay), QueryKeys.CategoryLetter, this.AdvertiserDisplayControl1.RequestedLetter);
                }
            }
        }

    }
}