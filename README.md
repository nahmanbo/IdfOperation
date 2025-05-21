# IdfOperation
Repo Manager:Nachman Ben Or
First Contributor:Yoel Ider

IDF Operation � First Strike: Organization Structure
Hierarchy

Organization: Top-level entity (e.g., IDF, Hamas), implemented via IOrganization.
IDF:
Fire Array: Manages strike units (F16, Hermes 460, M109).
AMAN: Military Intelligence branch, generates intelligence messages.


Hamas:
Fire Array: Manages strike units (Qassam Brigades).





Interfaces and Classes
Interface: IOrganization

Role: Defines core behavior for any organization, enabling future additions (e.g., Hezbollah).
Methods:
getName(): Returns organization name (e.g., "IDF", "Hamas").
getEstablishmentDate(): Returns date of establishment.
getCommander(): Returns current commander/leader name.
getFireArray(): Returns the fire array (strike units).
getIntelligence(): Returns intelligence branch (if applicable).
executeOperation(target): Initiates an operation (e.g., strike) on a target.



IDF

Role: Israeli Defense Forces, coordinating strikes and intelligence.
Implements: IOrganization.
Properties:
Name: "IDF".
Date of establishment: 1948.
Current commander.
Fire Array: Collection of strike units.
AMAN: Intelligence branch.


Responsibilities: Manages strikes and intelligence operations.

Hamas

Role: Palestinian militant organization, governing Gaza and conducting attacks.
Implements: IOrganization.
Properties:
Name: "Hamas".
Date of establishment: 1987.
Current commander: Committee-based leadership.
Fire Array: Qassam Brigades (rocket units, infantry).
List of affiliated terrorists.


Responsibilities: Conducts attacks, manages operatives.

Interface: IFireArray

Role: Manages strike units.
Methods:
getStrikeUnits(): Returns list of strike units.
addStrikeUnit(unit): Adds a new strike unit.
getAvailableUnits(): Returns units with remaining ammo.



Fire Array

Role: Manages strike units under an organization.
Implements: IFireArray.
Properties:
IDF: F16, Hermes 460, M109.
Hamas: Qassam Brigades (rocket launchers, infantry units).


Responsibilities: Tracks and deploys strike units.

Interface: IStrikeUnit

Role: Defines core behavior for all strike units.
Methods:
getName(): Returns unit name (e.g., "F16", "Qassam Rocket").
getAmmoCapacity(): Returns remaining strikes.
consumeAmmo(): Reduces ammo after a strike.
canStrikeTarget(targetType): Checks if unit can hit a target type.
getTargetType(): Returns effective target type.



Interface: IFuelable (Optional)

Role: For strike units requiring fuel.
Methods:
getFuelLevel(): Returns current fuel.
consumeFuel(amount): Reduces fuel.
refuel(): Restores fuel.



Strike Units (IDF)
F16 Fighter Jet (IStrikeUnit, IFuelable)

Properties:
Ammo: 8 strikes.
Targets: Buildings.
Features: 0.5/1-ton bombs, pilot-operated, uses fuel.



Hermes 460 Drone (IStrikeUnit, IFuelable)

Properties:
Ammo: 3 strikes.
Targets: People, Vehicles.
Features: Target-specific bombs, uses fuel.



M109 Artillery (IStrikeUnit)

Properties:
Ammo: 40 strikes.
Targets: OpenArea.
Features: Hits 2�3 targets at once, no fuel.



Strike Units (Hamas)
Qassam Brigades (IStrikeUnit)

Properties:
Ammo: Varies (e.g., rockets, small arms).
Targets: Civilians, Military.
Features: Rocket attacks, guerilla tactics, no fuel.



Interface: IAMAN

Role: Defines behavior for intelligence operations (IDF-specific).
Methods:
generateIntelMessage(terrorist, location, timestamp): Creates a new intelligence message.
getIntelMessages(): Returns all intelligence messages.
getIntelByTerrorist(terrorist): Returns messages for a specific terrorist.



AMAN

Role: Military Intelligence branch under IDF.
Implements: IAMAN.
Properties:
List of intelligence messages (linked terrorist, location, timestamp).


Responsibilities: Generates and manages intelligence for strike planning.

