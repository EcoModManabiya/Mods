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
    
    [RequiresSkill(typeof(MYBestSmellSkill), 4)]    
    public partial class MYMisoAndSoySauceRecipe : Recipe
    {
        public MYMisoAndSoySauceRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYMisoItem>(10),
                new CraftingElement<MYSoySauceItem>(10),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeansItem>(20), 
                new CraftingElement<MYSaltItem>(typeof(MYBestSmellEfficiencySkill), 10, MYBestSmellEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<YeastItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYMisoAndSoySauceRecipe), Item.Get<MYMisoItem>().UILink(), 120, typeof(MYBestSmellSpeedSkill)); 
            this.Initialize("Miso And Soy Sauce", typeof(MYMisoAndSoySauceRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}