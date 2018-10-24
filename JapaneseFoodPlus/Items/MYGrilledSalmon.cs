namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [RequiresModule(typeof(MYFlyingPanObject))]          
    [RequiresSkill(typeof(MYCharcoalGrillSkill), 1)]    
    public partial class MYGrilledSalmonRecipe : Recipe
    {
        public MYGrilledSalmonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGrilledFishItem>(),
                new CraftingElement<GarbageItem>(typeof(MYCharcoalGrillEfficiencySkill), 1, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SalmonItem>(1), 
                new CraftingElement<MYSaltItem>(typeof(MYCharcoalGrillEfficiencySkill), 10, MYCharcoalGrillEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYGrilledSalmonRecipe), Item.Get<MYGrilledFishItem>().UILink(), 15, typeof(MYCharcoalGrillSpeedSkill)); 
            this.Initialize("Grilled Salmon", typeof(MYGrilledSalmonRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}