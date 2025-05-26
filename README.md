# IdfOperation

## Overview

`IdfOperation` is a C# simulation project that models the operational structure and activities of the Israeli Defense Forces (IDF) and Hamas. It integrates firepower management, intelligence gathering, and target elimination workflows based on threat assessments.

The system emphasizes **OOP principles**, including **inheritance**, **abstraction**, and **encapsulation**, and demonstrates a **modular design** that supports future expansion.

---

## Project Structure

### 🧩 Core Entities

| Class         | Description                                                                 |
|---------------|-----------------------------------------------------------------------------|
| `Organization`| Abstract base class for both IDF and Hamas. Manages commander and est. date.|
| `Idf`         | Inherits `Organization`. Contains Firepower and Intelligence divisions.     |
| `Hamas`       | Inherits `Organization`. Holds a list of `Terrorist` objects.               |

---

### 🔥 Firepower System

| Class             | Description                                                                 |
|------------------|-----------------------------------------------------------------------------|
| `Weapon`          | Abstract base class for all weapons. Contains ammo, targets, and attack logic. |
| `IFuelable`       | Interface for fuel-consuming weapons.                                       |
| `F16`, `Tank`, `Zik`, `EyeFire` | Inherit from `Weapon`. Implement different ammo usage and fuel behaviors.|
| `FirepowerDivision`| Initializes and manages weapons by effective target type.                |

---

### 🕵️ Intelligence System

| Class                  | Description                                                             |
|------------------------|-------------------------------------------------------------------------|
| `Terrorist`            | Represents a Hamas operative. Has name, rank, alive status, and weapons.|
| `TerroristGenerator`   | Static utility to generate random `Terrorist` instances.                |
| `IntelligenceReport`   | Holds information about a terrorist and calculates threat level.        |
| `IntelligenceDivision` | Manages a list of reports and provides search/filter methods.          |

---

### 🧠 Operation Management

| Class             | Description                                                                 |
|------------------|-----------------------------------------------------------------------------|
| `OperationManager`| Provides a console-based menu to perform operations such as viewing data and eliminating terrorists. |
| `Program`         | Entry point of the system. Instantiates Hamas, IDF, and OperationManager.    |

---

## Functionality

- View complete IDF or Hamas details.
- Browse Firepower and Intelligence data.
- Search for terrorist reports by name.
- Identify and eliminate the most dangerous terrorist.
- Eliminate terrorists by location/type using appropriate weapons.
- Track fuel and ammo consumption during operations.

---

## Menu Options

1. **View full IDF information**
2. **View full Hamas information**
3. **View Firepower Division data**
4. **View Intelligence Division reports**
5. **View terrorist report by name**
6. **View most dangerous terrorist report**
7. **Eliminate terrorist by name**
8. **Eliminate the most dangerous terrorist**
9. **Eliminate terrorists by target type**
10. **Exit**


---

## Design Principles

- **Single Responsibility**: Each class has a distinct role (e.g., weapon logic, intelligence processing).
- **Open/Closed**: Adding new weapons or intelligence features requires minimal code changes.
- **Encapsulation**: Internal states like fuel, ammo, and report details are managed internally with controlled access.
- **Polymorphism**: Weapon behaviors vary by subclass and are invoked dynamically via base class references.

---

## Future Improvements

- GUI interface instead of console.
- Persistence layer for terrorist data and reports.
- Simulation of real-time intelligence and automated decision-making.

---

## Authors

Developed by [Yoel Ider and Nahman Ben Or](https://github.com/nahmanbo).



