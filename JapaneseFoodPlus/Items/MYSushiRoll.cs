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
    [Weight(100)]                                          
    public partial class MYSushiRollItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Sushi Roll"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Sushi Roll"; } } 
        public override string Description                      { get { return "The maki-sushi hand rooled sushi."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 59, Fat = 3, Protein = 8, Vitamins = 4};
        public override float Calories                          { get { return 313; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresModule(typeof(MYCuttingBoardObject))]          
    [RequiresSkill(typeof(MYHighestNigiriSkill), 3)]    
    public partial class MYSushiRollRecipe : Recipe
    {
        public MYSushiRollRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYSushiRollItem>(2),
                new CraftingElement<MYWoodenPlateItem>(typeof(MYHighestNigiriEfficiencySkill), 40, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GarbageItem>(typeof(MYHighestNigiriEfficiencySkill), 1, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYSashimiItem>(typeof(MYHighestNigiriEfficiencySkill), 20, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<RiceItem>(typeof(MYHighestNigiriEfficiencySkill), 20, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYEggItem>(typeof(MYHighestNigiriEfficiencySkill), 20, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYPickleItem>(typeof(MYHighestNigiriEfficiencySkill), 20, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYNoriItem>(typeof(MYHighestNigiriEfficiencySkill), 10, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlateItem>(2), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYSushiRollRecipe), Item.Get<MYSushiRollItem>().UILink(), 5, typeof(MYHighestNigiriSpeedSkill)); 
            this.Initialize("Sushi Roll", typeof(MYSushiRollRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}