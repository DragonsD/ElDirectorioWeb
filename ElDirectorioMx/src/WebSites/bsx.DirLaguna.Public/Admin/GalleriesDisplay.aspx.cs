using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public.Admin
{
    public partial class GalleriesDisplay : SimpleDisplayPage
    {
        public override ObjectDataSource MainDataSource
        {
            get { throw new NotImplementedException(); }
        }

        public override GridView MainGridView
        {
            get { throw new NotImplementedException(); }
        }

        public override LinkButton MainNewButton
        {
            get { throw new NotImplementedException(); }
        }

        public override LinkButton MainSearchButton
        {
            get { throw new NotImplementedException(); }
        }

        public override LinkButton MainCleanButton
        {
            get { throw new NotImplementedException(); }
        }

        public override string ElementFormUrl
        {
            get { throw new NotImplementedException(); }
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void CleanFilterControls()
        {
            throw new NotImplementedException();
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}