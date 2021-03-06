﻿using Sjerrul.CharacterForge.Builder.Factories;
using Sjerrul.CharacterForge.Builder.Rules;
using Sjerrul.CharacterForge.Builder.Violations;
using Sjerrul.CharacterForge.Core;
using Sjerrul.CharacterForge.Utilities.Assertion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.CharacterForge.Builder
{
    public class Rulebook : IRulebook
    {
        private readonly IEnumerable<IRule> rules;

        public Rulebook(IRulesFactory rulesFactory)
        {
            Guard.Against.ArgumentNull(rulesFactory, nameof(rulesFactory));

            this.rules = rulesFactory.BuildRuleset();
        }

        public IEnumerable<IViolation> CheckRules(ICharacter character)
        {
            Guard.Against.ArgumentNull(character, nameof(character));

            IEnumerable<IViolation> violations = Enumerable.Empty<IViolation>();
            foreach (var rule in this.rules)
            {
                var ruleViolations = rule.Check(character);
                violations = violations.Concat(ruleViolations);
            }

            return violations;
        }
    }
}
