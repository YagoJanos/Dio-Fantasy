# Dio Fantasy

## Um rpg de terminal desenvolvido em .NET Core

Seguindo a proposta do desafio do bootcamp da GFT, desenvolvi uma classe abstrata chamada NPC que possui os atributos comuns por trás de todos os personagens do RPG:

- Name

- Level
- Experience
- CombatType 

- BodyAttackDamage
- BodyAttackEnergyCost 

- MagicAttackDamage
- MagicAttackMagicCost 

- MaxHealthPoints
- HealthPoints
- BonusClassHealthPointsPerLevel 

- MaxEnergyPoints
- EnergyPoints
- EnergyPointsRecoveredPerRound 
- BonusClassEnergyPointsPerLevel 

- MaxMagicPoints  
- MagicPoints 
- MagicPointsRecoveredPerRound
- BonusClassMagicPointsPerLevel 

- Shield

Essa classe NPC é herdada por outras duas classes abstratas mais especializadas chamadas Warrior e Wizard representando respectivamente a superclasse de guerreiros que atacam corpo a corpo e magos. 
Organizei dessa forma para caso haja necessidades futuras de criação de atributos e métodos comuns a todos os guerreiros e a todos os magos.
Warrior é herdada pelas classes concretas Knight e Ninja e Wizard é herdada pelas classes concretas BlackWizard e WhiteWizard.

Adicionei mecânicas de ataque corpo a corpo e mecânicas de ataques mágicos.

O jogo completo está quase totalmente concluído, só sendo necessário resolver alguns bugs, e já contem quase que totalmente implementado sistema de fases, level de personagens baseados em XP e mudnaça de turnos.
