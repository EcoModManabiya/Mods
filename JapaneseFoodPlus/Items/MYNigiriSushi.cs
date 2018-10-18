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
    public partial class MYNigiriSushiItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Nigiri Sushi"; } }
        public override string Description                      { get { return "It is the sushi which the finger sushi puts a sushi seed on the nubbin of the vinegar meal and made."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 11, Fat = 1, Protein = 4, Vitamins = 0};
        public override float Calories                          { get { return 68; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHighestNigiriSkill), 4)]    
    public partial class MYNigiriSushiRecipe : Recipe
    {
        public MYNigiriSushiRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNigiriSushiItem>(1),
                new CraftingElement<MYWoodenPlatterItem>(1),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYSashimiItem>(1), 
                new CraftingElement<RiceItem>(typeof(MYHighestNigiriEfficiencySkill), 20, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlatterItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNigiriSushiRecipe), Item.Get<MYNigiriSushiItem>().UILink(), 5, typeof(MYHighestNigiriSpeedSkill)); 
            this.Initialize("Nigiri Sushi", typeof(MYNigiriSushiRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}