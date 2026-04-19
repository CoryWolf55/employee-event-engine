# Employee Event Engine

A backend-focused system for tracking employee activity through events and evaluating behavior using rule-based scoring.

This project models how real-world workforce systems operate by separating **what happened** (events) from **how it’s interpreted** (rules).

---

## 🚀 Purpose

Instead of storing arbitrary “scores,” this system captures **immutable work events** and derives insights from them.

It answers questions like:
- What actually happened over time?
- How can performance be evaluated based on real actions?
- How do rules evolve without breaking historical data?

---

## 🧠 Core Concepts

### Events as the Source of Truth
All employee activity is recorded as events:
- Clock In / Clock Out  
- Task Completed  
- Missed Shift  
- Custom events (extendable)

Events are **never modified** once created.

---

### Scoring as a Projection
Employee scores are not stored directly.

They are computed by applying rules to historical events:
- Attendance scoring  
- Task completion weighting  
- Penalties for missed actions  

This keeps the system flexible and realistic.

---

### Rule-Based Evaluation
Rules define how events translate into meaningful insights.

Examples:
- +10 for on-time clock-in  
- -20 for missed shift  
- +5 per completed task  

Rules can evolve without changing stored data.

---

## ⚙️ Features

- Event-driven activity tracking  
- Immutable event storage  
- Rule-based scoring system  
- Clean separation of data and logic  
- Console-based execution (no UI)  

---

## ▶️ Example Flow

1. Create an employee  
2. Record events (clock in, tasks, etc.)  
3. Run evaluation engine  
4. Output calculated score  

---

## 🧪 Why This Project Exists

This is not a production HR system.

It exists to practice and demonstrate:
- Event-driven design  
- Separation of concerns  
- Rule engines  
- Backend system modeling  
- Clean, extensible architecture  

---

## 🚫 Non-Goals

- No frontend/UI  
- No real employee monitoring  
- No hiring platform  
- No production deployment focus  

---

## 🔮 Future Ideas

- Rule versioning  
- Persistent storage (database)  
- Event replay system  
- Scheduling / time-based simulations  
- API layer (optional)  

---

## 📌 Summary

This project follows a simple but powerful principle:

> Store what happened.  
> Derive meaning later.
