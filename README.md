# Prize Wheels

_A tool for creating simple interactive prize wheels!_

EASY SET UP! SOME CODING REQUIRED

---

### Key components:

1. **PrizeWheel**
   * Use StartSpinning() and Stop() to start and stop the wheel.
   * Value is always an int, but this can be used by other scripts for custom functionality.
   * Place on any gameobject with a _Button_ component.
   * Available events: OnValueChanged, OnStateChanged, OnResult<int>


2. **PrizeWheelStopButton**
   * Place on any UI button.
   * Calls Stop() on the referenced PrizeWheel when clicked.


3. **PrizeWheelTickSoundEffect**
   * Plays an AudioClip whenever the value of the referenced PrizeWheel changes.