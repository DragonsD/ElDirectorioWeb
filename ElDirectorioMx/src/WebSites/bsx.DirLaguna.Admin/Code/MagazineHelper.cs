using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using bsx.DirLaguna.Dal;
using System.Configuration;
using System.IO;

namespace bsx.DirLaguna.Admin.Code
{
    public class MagazineHelper
    {
        StringBuilder builder;

        private string MagazinePath { get; set; }

        private string PagesFolder { get; set; }

        public MagazineHelper(string magazinePath, string pagesFolder)
        {
            this.builder = new StringBuilder();
            this.MagazinePath = magazinePath;
            this.PagesFolder = pagesFolder;
        }

        public bool PublishXmlMagazine()
        {
            bool result = false;
            try
            {
                this.BuildHeader();
                this.BuildItems();
                this.BuildFooter();
                using (StreamWriter outfile = new StreamWriter(this.MagazinePath + @"\config.xml"))
                {
                    outfile.Write(this.builder.ToString());
                    PageController controller = new PageController();
                    controller.UpdatePages(this.Pages);
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return result;
        }

        private void BuildHeader()
        {
            builder.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            builder.AppendLine("<MyFlipBook>");
            builder.AppendLine("	<Settings>");
            builder.AppendLine("		<!--The proportion of your page's width and height-->");
            builder.AppendLine("		<proportion>370:463</proportion>");
            builder.AppendLine("		<!--Max width of zoom in-->");
            builder.AppendLine("		<max_zoom_width>1920</max_zoom_width>");
            builder.AppendLine("		<!--zoom in 50% per step-->");
            builder.AppendLine("		<zoom_scale_per_step>0.5</zoom_scale_per_step>");
            builder.AppendLine("		<!--Book's margin-->");
            builder.AppendLine("		<margin>140</margin>");
            builder.AppendLine(@"		<!--Default book's middle shadow alpha , if use ""0"" ,no shadow -->");
            builder.AppendLine("		<global_middle_shadow_alpha>0.6</global_middle_shadow_alpha>");
            builder.AppendLine("		<!--If allow bitmap smoothing-->");
            builder.AppendLine("		<bitmap_smoothing>true</bitmap_smoothing>");
            builder.AppendLine("		<!--If book's cover zoomable, default - false -->");
            builder.AppendLine("		<book_cover_zoom_able>true</book_cover_zoom_able>");
            builder.AppendLine("		<!---->");
            builder.AppendLine("		<Hyperlink>http://eldirectorio.mx/</Hyperlink>");
            builder.AppendLine("	</Settings>");
            builder.AppendLine("	<Pages>");
        }

        private void BuildFooter()
        {
            builder.AppendLine("	</Pages>");
            builder.AppendLine("</MyFlipBook>");
        }

        private List<Page> Pages;

        private void BuildItems()
        {
            PageController controller = new PageController();

            this.Pages = new PageController().FetchAll().OrderBy(x => x.Number).ToList();
            int count = 0;
            foreach (var item in this.Pages)
            {
                builder.AppendLine("            <page>");
                builder.AppendLine("                <pageType>single</pageType>");
                builder.AppendFormat("                <pageURL>{0}</pageURL>",
                                            string.Format("{0}{1}{2}",
                                                Properties.Settings.Default.MagazineServer,
                                                this.PagesFolder,
                                                item.MagazinePageName));
                item.SyncNumber = ++count;

                builder.AppendLine();
                builder.AppendLine("            </page>");
            }

            if (this.Pages.Count % 2 != 0)
            {
                builder.AppendLine("            <page>");
                builder.AppendLine("                <pageType>single</pageType>");
                builder.AppendFormat("                <pageURL>{0}</pageURL>",
                                            string.Format("{0}{1}{2}",
                                                Properties.Settings.Default.MagazineServer,
                                                this.PagesFolder,
                                                Navigation.Config.MagazineBankPage));
                builder.AppendLine();
                builder.AppendLine("            </page>");
            }
        }
    }
}