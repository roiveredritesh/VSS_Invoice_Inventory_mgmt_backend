using System.ComponentModel.DataAnnotations;

namespace Invoice_Inventory_mgmt.Model
{
    public class CityMaster
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        public int StateID { get; set; }
        public StateMaster? stateMaster { get; set; }
       
    }
}
