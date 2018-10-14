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
    [Weight(10)]                                          
    public partial class MYSaltedPlumItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Salted Plum"; } }
        public override string Description                      { get { return "After having done food preserved in salt, I dried the fruit of the plum in the sun. It is food used for a rice ball and a lunch in Japan and is known as a health food."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 11; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYBestSmellSkill), 2)]    
    public partial class MYSaltedPlumRecipe : Recipe
    {
        public MYSaltedPlumRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSaltedPlumItem>(20),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYPlumItem>(20), 
                new CraftingElement<MYSaltItem>(typeof(MYBestSmellEfficiencySkill), 20, MYBestSmellEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSaltedPlumRecipe), Item.Get<MYSaltedPlumItem>().UILink(), 120, typeof(MYBestSmellSpeedSkill)); 
            this.Initialize("Salted Plum", typeof(MYSaltedPlumRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}