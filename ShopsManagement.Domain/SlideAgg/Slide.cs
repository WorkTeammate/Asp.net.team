using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTittle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string Link { get; private set; }
        public bool IsDeleted { get; private set; }

        protected Slide()
        {

        }

        public Slide(string picture, string pictureAlt
            , string pictureTittle, string heading, string title
            , string text, string btnText, string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTittle = pictureTittle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
            IsDeleted = false;
        }
        public void Edit(string pictureAlt
            , string pictureTittle, string heading, string title
            , string text, string btnText, string link)
        {
            PictureAlt = pictureAlt;
            PictureTittle = pictureTittle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
        }

        public void EditPicture(string picture)
        {
            Picture = picture;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted= false;
        }
    }
}
