using DatabaseLib.DAL;
using DatabaseLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class Tags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administrator"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            IList<UnusedTag> unusedTags = ((IRepo)Application["database"]).SelectUnusedTags();

            UnusedTagsRepeater.DataSource = unusedTags;
            UnusedTagsRepeater.DataBind();

            IList<AssignedTag> assignedTags = ((IRepo)Application["database"]).SelectAssignedTags();

            AssignedTagsRepeater.DataSource = assignedTags;
            AssignedTagsRepeater.DataBind();

            if (!IsPostBack)
            {
                FillDropdowns();
            }

            
        }

        private void FillDropdowns()
        {
            IList<TagType> tagTypes = ((IRepo)Application["database"]).GetTagTypes();

            tagType.DataSource = from tt in tagTypes
                                 select new ListItem()
                                 {
                                     Text = tt.Name,
                                     Value = tt.Id.ToString()
                                 };
            tagType.DataBind();

            IList<Apartment> apartments = ((IRepo)Application["database"]).SelectApartments();

            Apartments.DataSource = from a in apartments
                                    select new ListItem()
                                    {
                                        Text = a.Name
                                    };
            Apartments.DataBind();

            IList<string> tagNames = ((IRepo)Application["database"]).GetTagNames();

            TagsForAp.DataSource = from tagName in tagNames
                                   select new ListItem()
                                   {
                                       Text = tagName
                                   };
            TagsForAp.DataBind();


        }

        protected void btnUnused_Click(object sender, EventArgs e)
        {
            UnusedTags.Visible = true;
            AssignedTags.Visible = false;
            AddNewTag.Visible = false;
            AddTagToApartment.Visible = false;
        }

        protected void btnAssigned_Click(object sender, EventArgs e)
        {
            UnusedTags.Visible = false;
            AssignedTags.Visible = true;
            AddNewTag.Visible = false;
            AddTagToApartment.Visible = false;
        }

        protected void btnAddNewTag_Click(object sender, EventArgs e)
        {
            UnusedTags.Visible = false;
            AssignedTags.Visible = false;
            AddNewTag.Visible = true;
            AddTagToApartment.Visible = false;
        }

        protected void btnTagApartment_Click(object sender, EventArgs e)
        {
            UnusedTags.Visible = false;
            AssignedTags.Visible = false;
            AddNewTag.Visible = false;
            AddTagToApartment.Visible = true;
        }

        protected void addNewTagClick(object sender, EventArgs e)
        {

            if (tagNameEng.Text == "" || tagNameCro.Text == "")
            {
                fieldWarning.Text = "molimo popunite sva polja";
            }
            else
            {
                
                int id = ((IRepo)Application["database"]).GetTagTypeId(tagType.SelectedItem.Text);
                string tagNameC = tagNameCro.Text;
                string tagNameE = tagNameEng.Text;

                try
                {
                    ((IRepo)Application["database"]).InsertTag(id, tagNameC, tagNameE);
                    
                }
                catch (Exception)
                {

                    Response.Redirect("Error.aspx");
                }

                Response.Redirect("Tags.aspx");

            }

            
        }

        protected void addTagToApartmentClick(object sender, EventArgs e)
        {
            string apName = Apartments.SelectedItem.Text;
            string tagName = TagsForAp.SelectedItem.Text;

            int apId = ((IRepo)Application["database"]).GetApIdByName(apName);
            int tagId = ((IRepo)Application["database"]).GetTagIdByName(tagName);

            ((IRepo)Application["database"]).AddTagToApartment(apId, tagId);

            Response.Redirect("Tags.aspx");
        }


        protected void btnUnusedDelete_Click(object sender, EventArgs e)
        {
            int tagId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ((IRepo)Application["database"]).DeleteTag(tagId);
            Response.Redirect("Tags.aspx");
            
        }
    }
}