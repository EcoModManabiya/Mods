namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    using System.Linq;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.View;
    using Eco.Gameplay.Systems;

    using Core.Controller;
    using Core.Items;
    using Core.Utils;
    using Eco.Gameplay.Economy;
    using Simulation.Types;
	using Eco.Gameplay.Interactions;
	
    public partial class MYAnimalBoxRecipe : Recipe
    {
        public MYAnimalBoxRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYAnimalBoxItem>(1),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTurkeyChickItem>(1), 
                new CraftingElement<MYTurkeyBaitItem>(typeof(SmallButcheryEfficiencySkill), 30, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYAnimalBoxRecipe), Item.Get<MYAnimalBoxItem>().UILink(), 240, typeof(SmallButcherySpeedSkill));    
            this.Initialize("Animal Box", typeof(MYAnimalBoxRecipe));

            CraftingComponent.AddRecipe(typeof(MYTurkeyHouseObject), this);
        }
    }

    [Serialized]
    [Weight(1000)]  
    [Currency]              
    public partial class MYAnimalBoxItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Animal Box"; } } 
        public override string Description { get { return ""; } }
		
		public override void OnUsed(Player player, ItemStack itemStack)
		{
			player.SendTemporaryMessageLoc("111");
			InventoryChangeSet changes = new InventoryChangeSet(player.User.Inventory, player.User);
			changes.AddItems<MYTurkeyBaitItem>(1);
		}
    }

}