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
    
    [RequiresSkill(typeof(FishingSkill), 4)]    
    public partial class MYSeaSaltRecipe : Recipe
    {
        public MYSeaSaltRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSaltItem>(10),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(FishingSkill), 20, FishingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSeaSaltRecipe), Item.Get<MYSaltItem>().UILink(), 10, typeof(FishingSkill)); 
            this.Initialize("Sea Salt", typeof(MYSeaSaltRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}