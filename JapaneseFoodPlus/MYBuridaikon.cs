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
    public partial class MYBuridaikonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Buridaikon"; } }
        public override string Description                      { get { return "The Japanese local cooking that the Buri-daikon boiled the ARA of the yellowtail hard with soy sauce with a Japanese radish."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 18, Fat = 20, Protein = 26, Vitamins = 4};
        public override float Calories                          { get { return 1080; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 3)]    
    public partial class MYBuridaikonRecipe : Recipe
    {
        public MYBuridaikonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYBuridaikonItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<BeetItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYBuridaikonRecipe), Item.Get<MYBuridaikonItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Buridaikon", typeof(MYBuridaikonRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}