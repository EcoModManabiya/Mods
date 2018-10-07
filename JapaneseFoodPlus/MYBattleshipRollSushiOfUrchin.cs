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

        private static Nutrients nutrition = new Nutrients()    { Carbs = 13, Fat = 1, Protein = 5, Vitamins = 0};
        public override float Calories                          { get { return 220; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 2)]    
    public partial class MYBattleshipRollSushiOfUrchinRecipe : Recipe
    {
        public MYBattleshipRollSushiOfUrchinRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBattleshipRollSushiOfUrchinItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<UrchinItem>(1), 
                new CraftingElement<MYNoriItem>(2), 
                new CraftingElement<RiceItem>(typeof(CulinaryArtsEfficiencySkill), 20, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBattleshipRollSushiOfUrchinRecipe), Item.Get<MYBattleshipRollSushiOfUrchinItem>().UILink(), 10, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Battleship Roll Sushi Of Urchin", typeof(MYBattleshipRollSushiOfUrchinRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}