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
    public partial class MYBattleshipRollSushiOfUrchinItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Battleship Roll Sushi Of Urchin"; } }
        public override string Description                      { get { return "It is the sushi with the sushi class with laver with a vinegar meal on winding, the top. Because the figure resembled a warship, it was named."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 20, Fat = 2, Protein = 4, Vitamins = 2};
        public override float Calories                          { get { return 110; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYHighestNigiriSkill), 3)]    
    public partial class MYBattleshipRollSushiOfUrchinRecipe : Recipe
    {
        public MYBattleshipRollSushiOfUrchinRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBattleshipRollSushiOfUrchinItem>(2),
                new CraftingElement<GarbageItem>(typeof(MYHighestNigiriEfficiencySkill), 2, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<UrchinItem>(1), 
                new CraftingElement<MYNoriItem>(2), 
                new CraftingElement<RiceItem>(typeof(MYHighestNigiriEfficiencySkill), 20, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYHighestNigiriEfficiencySkill), 5, MYHighestNigiriEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenPlatterItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBattleshipRollSushiOfUrchinRecipe), Item.Get<MYBattleshipRollSushiOfUrchinItem>().UILink(), 10, typeof(MYHighestNigiriSpeedSkill)); 
            this.Initialize("Battleship Roll Sushi Of Urchin", typeof(MYBattleshipRollSushiOfUrchinRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}