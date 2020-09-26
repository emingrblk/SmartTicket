using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public class EndlessCategory : BaseEntitiy
    {
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        [DisplayName("Üst Kategori Id")]
        public int? ParentCategoryId { get; set; }

        //Aşagıdakiler de eklenebilir!
        [DisplayName("Action Adı")]         //Index gibi
        public string ActionName { get; set; }

        [DisplayName("Controller Adı")]     //Home gibi
        public string ControllerName { get; set; }

        [DisplayName("Sıra Numarası")]
        public int OrderNo { get; set; }  //? Orderno ile menünün sırası tutulabilir.

        public string QueryStrings { get; set; }

        //???  QueryStrings   "?lang=en&search=abc"  gibi

        //Bir kategorinin sonsuz alt kategorisi olabilirken bir tane parent kategorisi olabilir!
        public virtual EndlessCategory ParentCategory { get; set; }
        public virtual ICollection<EndlessCategory> EndlessCategories { get; set; }
    }
}
