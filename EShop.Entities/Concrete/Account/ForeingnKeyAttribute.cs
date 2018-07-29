using System;

namespace EShop.Entities.Concrete.Account
{
    internal class ForeingnKeyAttribute : Attribute
    {
        private string v;

        public ForeingnKeyAttribute(string v)
        {
            this.v = v;
        }
    }
}