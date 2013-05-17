using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal;
using System.Configuration;
using System.Web;

namespace bsx.DirLaguna.CommonWeb
{
    public class MapHelper
    {
        public bool FilterFeatured { get; set; }

        public string RequestedCategory { get; set; }

        public string Keywords { get; set; }

        public int CityId { get; set; }

        public int ZoomLevel { get; set; }

        public int AdvetiserId { get; set; }

        private string SiteUrl { get; set; }

        private string DetailFormUrl { get; set; }

        public MapHelper(string siteUrl, string detailFormUrl)
        {
            this.SiteUrl = siteUrl;
            this.DetailFormUrl = detailFormUrl;
            this.FilterFeatured = false;
            this.RequestedCategory = string.Empty;
            this.Keywords = string.Empty;
            this.ZoomLevel = (int)ZoomLevelEnum.Middle;
            this.CityId = -1;
        }

        public MapHelper(bool filterFeatured, string requestedCategory, string keywords, int cityId, string siteUrl, string detailFormUrl)
            : this(siteUrl, detailFormUrl)
        {
            this.FilterFeatured = filterFeatured;
            this.RequestedCategory = requestedCategory;
            this.Keywords = keywords;
            this.CityId = cityId;
        }

        public void DiggMarkers(List<Marker> markers, IQueryable<Advertiser> advertisers)
        {
            foreach (var adv in advertisers)
            {
                if (string.IsNullOrEmpty(adv.MapReferenceX.ToString()) || string.IsNullOrEmpty(adv.MapReferenceY.ToString()))
                    continue;

                int officesCount = adv.ActiveOfficesCount;

                foreach (Office office in adv.ActiveOffices)
                    if (office.MapReferenceX.HasValue && office.MapReferenceY.HasValue)
                    {
                        // si dispongo de la ciudad filtro unicamente auqellas que pertenescan a la ciudad. si no, las agrego todas.
                        if (this.CityId > 0)
                        {
                            if (office.CityId == this.CityId)
                                markers.Add(new Marker()
                                {
                                    Name = string.Format(officesCount == 1 ? "{0}" : "{0}. {1}", HtmlText(adv.Name), HtmlText(office.Name)),
                                    Address = office.HtmlAddress,
                                    City = office.City.Name,
                                    Url = string.Format("{0}{1}?{2}={3}", this.SiteUrl, this.DetailFormUrl, QueryKeys.AdvertiserId, adv.AdvertiserId),
                                    LatLn = string.Format("{0},{1}", office.MapReferenceX, office.MapReferenceY),
                                    pointX = office.MapReferenceX.Value,
                                    pointY = office.MapReferenceY.Value
                                });

                        }
                        else
                            markers.Add(new Marker()
                                            {
                                                Name = string.Format(officesCount == 1 ? "{0}" : "{0}. {1}", HtmlText(adv.Name), HtmlText(office.Name)),
                                                Address = office.HtmlAddress,
                                                City = office.City.Name,
                                                Url = string.Format("{0}{1}?{2}={3}", this.SiteUrl, this.DetailFormUrl, QueryKeys.AdvertiserId, adv.AdvertiserId),
                                                LatLn = string.Format("{0},{1}", office.MapReferenceX, office.MapReferenceY),
                                                pointX = office.MapReferenceX.Value,
                                                pointY = office.MapReferenceY.Value
                                            });
                    }
            }
        }

        public static string EncodeJsString(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");

            return sb.ToString();
        }


        private string HtmlText(string text)
        {
            string aux = text.Replace("'", " ");
            aux = aux.Replace('"', ' ');
            aux = aux.Replace("\"", " ");
            return aux;
        }

        public string MapScript
        {
            get
            {
                VwAdvertiserController controller = new VwAdvertiserController();

                AdvertiserController advController = new AdvertiserController();

                IQueryable<Advertiser> advertisers = this.AdvetiserId == 0 ?
                    advController.FetchFromIds((from x in controller.FetchCategoryAdvertisers(this.RequestedCategory, this.Keywords, this.CityId) select x.AdvertiserId).ToList()) :
                    advController.FetchByQueryableId(this.AdvetiserId);

                //IQueryable<Advertiser> advertisers = this.AdvetiserId == 0 ?
                //    controller.FetchCategoryAdvertisers(this.FilterFeatured, this.RequestedCategory, this.Keywords, this.CityId) :
                //    controller.FetchMapAdvertiser(this.AdvetiserId);


                List<Marker> aux = new List<Marker>();
                this.DiggMarkers(aux, advertisers);

                if (aux.Count == 0 && this.EmptyList != null)
                    this.EmptyList(this, EventArgs.Empty);

                return @"function initialize() {
    var myOptions = {" + this.OneItemSetup(aux) + @"mapTypeId: google.maps.MapTypeId.ROADMAP};
    var map = new google.maps.Map(document.getElementById(""map_canvas""),myOptions);
    " + this.ManyItemsSetup(aux) + this.BuildMarkers(aux) + @"
}";
            }
        }

        public event EventHandler EmptyList;

        private string OneItemSetup(List<Marker> markers)
        {
            if (markers.Count != 1)
                return string.Empty;

            return string.Format("center: {0}, zoom: {1}, ",
                string.Format("new google.maps.LatLng({0},{1})", markers[0].pointX, markers[0].pointY),
                (int)ZoomLevelEnum.Near);
        }

        private string ManyItemsSetup(List<Marker> markers)
        {
            if (markers.Count < 2)
                return string.Empty;

            var minLat = (from x in markers orderby x.pointX ascending select x).FirstOrDefault();
            var maxLat = (from x in markers orderby x.pointX descending select x).FirstOrDefault();
            var minLon = (from x in markers orderby x.pointY ascending select x).FirstOrDefault();
            var maxLon = (from x in markers orderby x.pointY descending select x).FirstOrDefault();

            StringBuilder builder = new StringBuilder();
            builder = builder.AppendLine("var llbounds = new google.maps.LatLngBounds();");
            builder = builder.AppendLine(this.SetPointBound(minLat));
            builder = builder.AppendLine(this.SetPointBound(maxLat));
            builder = builder.AppendLine(this.SetPointBound(minLon));
            builder = builder.AppendLine(this.SetPointBound(maxLon));
            builder = builder.AppendLine("map.fitBounds( llbounds );");
            builder = builder.AppendLine();

            return builder.ToString();
        }

        private string SetPointBound(Marker marker) { return string.Format("llbounds.extend(new google.maps.LatLng({0}, {1}));", marker.pointX, marker.pointY); }

        public string BuildMarkers(List<Marker> advertisers)
        {
            StringBuilder builder = new StringBuilder();
            int count = 0;
            foreach (var item in advertisers)
            {
                builder.AppendLine("var contentString" + count + @" = '<div id=""infoWindow"">'+");
                builder.AppendLine(@"'<div id=""siteNotice"">'+");
                builder.AppendLine(string.Format(@"'<b><a href=""{1}"">{0}</a></b>'+", item.Name, item.Url));
                builder.AppendLine(string.Format("'<div>{0}</div>'+", item.Address));
                builder.AppendLine(string.Format("'<div>{0}</div>'+", item.City));
                builder.AppendLine("'</div>'+");
                builder.AppendLine("'</div>'");
                builder.AppendLine();

                string infoWindow = "var infowindow" + count + " = new google.maps.InfoWindow({0}content: contentString" + count + "{1});";
                builder = builder.AppendFormat(infoWindow, '{', '}');

                string marker = "var marker" + count + " = new google.maps.Marker({2}position: new google.maps.LatLng({0}), map: map, title: \"{1}\"{3});\n";
                builder = builder.AppendFormat(marker, item.LatLn, item.Name, '{', '}');
                builder.AppendLine();

                string listener = "google.maps.event.addListener(marker" + count + ", 'click', function() {0} infowindow" + count + ".open(map,marker" + count + "); {1});";
                builder = builder.AppendFormat(listener, '{', '}');
                builder.AppendLine();

                count++;
            }

            return builder.ToString();
        }

        public enum ZoomLevelEnum
        {
            Near = 17,
            Middle = 12,
            Far = 10
        }
    }
}
