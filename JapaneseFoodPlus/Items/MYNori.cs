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
    public partial class MYNoriItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Nori"; } }
        public override string FriendlyNamePlural 　　　　　　　　　　　　　　{ get { return "Nori"; } } 
        public override string Description                      { get { return "A Japanese food called nori is a dried see weeds. They it is with rice and use for many dishes like sushi."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 1, Fat = 0, Protein = 1, Vitamins = 6};
        public override float Calories                          { get { return 6; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(FishingSkill), 4)]    
    public partial class MYNoriRecipe : Recipe
    {
        public MYNoriRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYNoriItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<KelpItem>(typeof(FishingSkill), 20, FishingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYNoriRecipe), Item.Get<MYNoriItem>().UILink(), 20, typeof(FishingSkill)); 
            this.Initialize("Nori", typeof(MYNoriRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}