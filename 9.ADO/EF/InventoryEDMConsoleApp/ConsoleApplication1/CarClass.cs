using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public partial class Car
    {
        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.
            return string.Format("{0} is a {1} {2} with ID {3}.",
            this.CarNickname ?? "**No Name**",
            this.Color, this.Make, this.CarID);
        }
    }
}

