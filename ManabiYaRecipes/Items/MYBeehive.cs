namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;

    [WorldSpaceItem]
    [StartsDiscovered]
    public partial class MYBeehiveItem : Item
    {
        public override string FriendlyName { get { return "Beehive"; } } 
        public override string Description { get { return "Honey should be removed from the hive."; } }
	}
}
