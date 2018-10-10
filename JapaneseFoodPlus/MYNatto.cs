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
    
    [Serialized]
    [Weight(50)]                                          
    public partial class MYNattoItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Natto"; } }
        public override string Description                      { get { return "The Japanese fermented food which let a soybean ferment by Bacillus natto as for the natto."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 1, Fat = 1, Protein = 2, Vitamins = 0};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 3)]    
    public partial class MYNattoRecipe : Recipe
    {
        public MYNattoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNattoItem>(5),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<YeastItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<PlantFibersItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BeansItem>(30), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNattoRecipe), Item.Get<MYNattoItem>().UILink(), 40, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Natto", typeof(MYNattoRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}