<div dir="rtl">

# 💻 البرمجة كائنية التوجه — المحاضرة 03: تعدد الأشكال (Polymorphism)، الربط الديناميكي، والكلاسات المختومة (Sealed)
### OOP Session 03: Polymorphism, Dynamic Binding (VTable), Sealed Classes & Class Relationships

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Module](https://img.shields.io/badge/Module-02_OOP-0284c7?style=for-the-badge)](#)
[![Interactive Guide](https://img.shields.io/badge/%F0%9F%8C%90_Live_Study_Guide-HTML_Interactive-8b5cf6?style=for-the-badge)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-03-Assigment/blob/master/Study_Guide/OOP_Session03_04_Dispatch_&_SOLID_Deep_Dive.html)

> **نبذة عن المشروع:** 🚀 [02 OOP - Session 03] Smart Delivery System (Part 2): Method Overloading vs Overriding, Static vs Dynamic Binding (VTable), Sealed Classes/Methods & Association/Aggregation/Composition.

---

## 🌐 الدليل التفاعلي المشروح بالـ HTML (Interactive Study Guide)

تم تضمين الدليل التفاعلي المشروح بالكامل داخل مجلد [`Study_Guide/`](./Study_Guide) في هذا المستودع، ويمكنك قراءته مباشرة في المتصفح عبر الروابط التالية:

- 🌐 الدليل التفاعلي الموسع: Method Dispatch (VTable) & SOLID (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-03-Assigment/blob/master/Study_Guide/OOP_Session03_04_Dispatch_&_SOLID_Deep_Dive.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/OOP_Session03_04_Dispatch_&_SOLID_Deep_Dive.html)**
- 📂 **[فتح مجلد المحاضرة المحلي الكامل في `nots` (للتصفح المحلي على الجهاز)](../../../../nots/02_OOP/Session_03_Polymorphism_&_Binding)**

---

### 🧠 الملاحظات الهندسية والمفاهيم المعمارية (Engineering Notes)
1. **الربط الثابت (`Static Binding`) مقابل الربط الديناميكي (`Dynamic Binding / VTable`):**
   - **Method Overloading (`UpdateWeight(decimal)` vs `UpdateWeight(decimal, decimal)`):** يحسمه المترجم وقت الترجمة (`Compile-Time`) بناءً على توقيع المعاملات ويصدر تعليمة IL مباشرة `call`.
   - **Method Overriding (`override PrintShipment()` و `override EstimatedCost`):** يحسمه الـ CLR وقت التشغيل (`Run-Time`) عبر تعليمة `callvirt` بالبحث في جدول الدوال الافتراضية (**VTable**) الخاص بالنوع الفعلي للكائن في الـ `Heap`.
2. **الكلاسات والدوال المختومة (`sealed class` & `sealed override`):**
   - **`CompletedShipment` (`sealed class`):** يمنع أي كلاس آخر من الوراثة منه، مما يحمي التصميم ويمكّن الـ JIT Compiler من تطبيق تحسين **Devirtualization** (تحويل الاستدعاء الافتراضي إلى استدعاء مباشر سريع).
   - **`PriorityInternationalShipment.GenerateCustomsReport()` (`sealed override`):** يسمح بالوراثة من الكلاس، لكنه يقفل دالة `GenerateCustomsReport` تحديداً لمنع أي تعديل إضافي عليها في الأحفاد.
3. **العلاقات بين الكلاسات (`Composition`, `Aggregation`, `Association`):**
   - **Composition:** علاقة احتواء كاملة بين `Shipment` و `DeliveryReport`.
   - **Aggregation:** علاقة تجميع بين `DeliveryCenter` ومصفوفة الشحنات `Shipment[]`.
   - **Association:** علاقة استخدام بين `Driver` والشحنة التي يقوم بتوصيلها.

---

## 🗂️ هيكلة الكود والتمارين التطبيقية المحلولة

| المكون | المفهوم المطبق | التفاصيل في الكود |
| :--- | :--- | :--- |
| **Part 01 (Q1 & Q2)** | Overloading vs Overriding & Sealed | شرح الفرق بين Static/Dynamic Binding والغرض المعماري من `sealed class` و `sealed method`. |
| **`Shipment.UpdateWeight`** | Compile-Time Overloading | نسختان من الدالة لتحديث الوزن بمفرده أو مع وزن التغليف الإضافي. |
| **`CompletedShipment`** | `sealed class` | كلاس نهائي لا يقبل الاشتقاق لتمثيل الشحنات المكتملة. |
| **`PriorityInternationalShipment`** | `sealed override` Method | يرث من `InternationalShipment` ويختم دالة `GenerateCustomsReport()`. |
| **`Driver` & `DeliveryReport`** | Class Relationships | تمثيل علاقات الترابط والاحتواء داخل منظومة التوصيل. |

---

## 🧭 خريطة مسار هندسة `.NET` الكامل على GitHub

| # | المرحلة (Module) | المستودع (Repository) | الموضوع الرئيسي | الدليل التفاعلي (Live HTML) |
| :---: | :--- | :--- | :--- | :---: |
| **01** | `01_CSharp_Basics` | **[`CSharp-Basics02-Assigment`](https://github.com/mohamedadel452/CSharp-Basics02-Assigment)** | أنواع البيانات، نموذج الكائنات (System.Object)، والتحويلات | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics02-Assigment/blob/master/Study_Guide/CSharp_Basics_Session02_Guide.html) |
| **02** | `01_CSharp_Basics` | **[`CSharp-Basics03-Assigment`](https://github.com/mohamedadel452/CSharp-Basics03-Assigment)** | معمارية النصوص (Strings & StringBuilder)، جمل التحكم، والحلقات | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics03-Assigment/blob/master/Study_Guide/CSharp_Basics_Session03_Guide.html) |
| **03** | `01_CSharp_Basics` | **[`CSharp-Basics04-Assigment`](https://github.com/mohamedadel452/CSharp-Basics04-Assigment)** | المصفوفات (1D & 2D Arrays) وتمرير المعاملات للدوال (Value / ref / out / params) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics04-Assigment/blob/master/Study_Guide/CSharp_Basics_Session04_Guide.html) |
| **04** | `01_CSharp_Basics` | **[`CSharp-Basics05-Assigment`](https://github.com/mohamedadel452/CSharp-Basics05-Assigment)** | محددات الوصول (Access Modifiers)، التغليف، والـ Enums | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics05-Assigment/blob/master/Study_Guide/CSharp_Basics_Session05_Guide.html) |
| **05** | `02_OOP` | **[`OOP-Session-01-Assigment`](https://github.com/mohamedadel452/OOP-Session-01-Assigment)** | الـ Struct، التغليف، الخصائص، والـ Indexers (نظام Smart Delivery) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-01-Assigment/blob/master/Study_Guide/OOP_Session01_Deep_Dive.html) |
| **06** | `02_OOP` | **[`OOP-Session-02-Assigment`](https://github.com/mohamedadel452/OOP-Session-02-Assigment)** | الفئات (Classes)، الوراثة، وتسلسل الـ Constructors (Smart Delivery Part 1) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-02-Assigment/blob/master/Study_Guide/OOP_Session02_Deep_Dive.html) |
| **07** | `02_OOP` | **[`OOP-Session-03-Assigment`](https://github.com/mohamedadel452/OOP-Session-03-Assigment)** | تعدد الأشكال (Polymorphism)، الربط الديناميكي، والكلاسات المختومة (Sealed) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-03-Assigment/blob/master/Study_Guide/OOP_Session03_04_Dispatch_&_SOLID_Deep_Dive.html) |
| **08** | `02_OOP` | **[`OOP-Session-04-Assigment`](https://github.com/mohamedadel452/OOP-Session-04-Assigment)** | التجريد (Abstraction)، الفئات المجردة، والواجهات (Smart Delivery Part 3) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-04-Assigment/blob/master/Study_Guide/OOP_Session04_Deep_Dive.html) |
| **09** | `02_OOP` | **[`OOP-Session-05-Assigment`](https://github.com/mohamedadel452/OOP-Session-05-Assigment)** | نسخ الكائنات، Static، دوال التوسيع، والـ Partial Classes (Smart Delivery Final) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-05-Assigment/blob/master/Study_Guide/OOP_Session05_Deep_Dive.html) |
| **10** | `03_Advanced_CSharp` | **[`Advanced-CSharp-01`](https://github.com/mohamedadel452/Advanced-CSharp-01)** | الأنواع المعممة (Generics)، القيود (Constraints)، والـ Variance | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part1_Core.html) |
| **11** | `03_Advanced_CSharp` | **[`Advanced-CSharp-02`](https://github.com/mohamedadel452/Advanced-CSharp-02)** | المفوضات (Delegates)، تعبيرات Lambda، ونظام ShopMaster | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part1_Core.html) |
| **12** | `03_Advanced_CSharp` | **[`Advanced-CSharp-03`](https://github.com/mohamedadel452/Advanced-CSharp-03)** | معمارية هياكل البيانات والـ Collections (6 أنظمة تطبيقية) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-03/blob/master/Study_Guide/session03-part1-collections-list.html) |
| **13** | `04_Database` | **[`Database-Session-01-Assigment`](https://github.com/mohamedadel452/Database-Session-01-Assigment)** | تصميم قواعد البيانات، مخططات الـ ERD، والتحويل العلائقي (Relational Mapping) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Database-Session-01-Assigment/blob/master/Study_Guide/ERD_Part1_Design_Intro.html) |

---

## 🚀 طريقة التشغيل المحلي (How to Run)

```bash
git clone https://github.com/mohamedadel452/OOP-Session-03-Assigment.git
cd OOP-Session-03-Assigment
dotnet run --project "OOP-Session-03-Assigment/OOP-Session-03-Assigment.csproj"
```

**إعداد وتطوير:** [محمد عادل محمد بيومي (mohamedadel452)](https://github.com/mohamedadel452) — كلية الحاسبات والمعلومات، جامعة عين شمس.

</div>
