
namespace DentalWarranty.Domain
{
    /// <summary>
    /// Role domain entity
    /// </summary>
   public class Role
    {
       /// <summary>
       /// Role Id
       /// </summary>
        public virtual int RoleId { get; set; }

       /// <summary>
       /// Role name
       /// </summary>
        public virtual string Name { get; set; }
    }
}
