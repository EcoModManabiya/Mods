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
    public partial class MYSushiRollItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Sushi Roll"; } }
        public override string Description                      { get { return "I point to the Japanese dish which I open a vinegar meal in the laver on the winding bamboo blind and put an ingredient on the top and wound up."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 1, Protein = 3, Vitamins = 1};
        public override float Calories                          { get { return 250; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 3)]    
    public partial class MYSushiRollRecipe : Recipe
    {
        public MYSushiRollRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSushiRollItem>(5),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYSashimiItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<RiceItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYEggItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYPickleItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYNoriItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSushiRollRecipe), Item.Get<MYSushiRollItem>().UILink(), 30, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Sushi Roll", typeof(MYSushiRollRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}