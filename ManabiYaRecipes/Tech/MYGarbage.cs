namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(SmithSkill), 0)]    
    public partial class MYGarbageSkill : Skill
    {
        public override string FriendlyName { get { return "Garbage"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class MYGarbageSkillBook : SkillBook<MYGarbageSkill, MYGarbageSkillScroll>
    {
        public override string FriendlyName { get { return "Garbage Skill Book"; } }
    }

    [Serialized]
    public partial class MYGarbageSkillScroll : SkillScroll<MYGarbageSkill, MYGarbageSkillBook>
    {
        public override string FriendlyName { get { return "Garbage Skill Scroll"; } }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)] 
    public partial class MYGarbageSkillBookRecipe : Recipe
    {
        public MYGarbageSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYGarbageSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(ResearchEfficiencySkill), 100, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PaperItem>(typeof(ResearchEfficiencySkill), 100, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CompositeFillerItem>(typeof(ResearchEfficiencySkill), 100, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronOreItem>(typeof(ResearchEfficiencySkill), 100, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(15);

            this.Initialize("Garbage Skill Book", typeof(MYGarbageSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
