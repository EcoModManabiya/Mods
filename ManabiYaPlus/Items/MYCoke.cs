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

    [RequiresSkill(typeof(MYRecyclingSkill), 3)] 
    public class MYMinorMetalRecipe : Recipe
    {
        public MYMinorMetalRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<MYMinorMetalItem>(typeof(MYRecyclingEfficiencySkill), 1f, MYRecyclingEfficiencySkill.MultiplicativeStrategy),
               new CraftingElement<TailingsItem>(typeof(MYRecyclingEfficiencySkill), 2.5f, MYRecyclingEfficiencySkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GoldIngotItem>(typeof(MYRecyclingEfficiencySkill), 5, MYRecyclingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Minor Metal", typeof(MYMinorMetalRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYMinorMetalRecipe), this.UILink(), 10f, typeof(MYRecyclingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MYRecycleFurnaceObject), this);
        }
    }

    [Serialized]
    [Weight(100)]      
    [Currency]              
    public partial class MYMinorMetalItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Minor Metal"; } } 
        public override string FriendlyNamePlural { get { return "Minor Metal"; } } 
        public override string Description { get { return "Minor metals are a material essential in the manufacture of high value-added/high function products."; } }

    }
}