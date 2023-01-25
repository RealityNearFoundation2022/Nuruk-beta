using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class ModelSync
{
    #region CustomClothes
    [RealtimeProperty(1, true, true)]
    private string _shirts;
    [RealtimeProperty(2, true, true)]
    private string _heads;
    [RealtimeProperty(3, true, true)]
    private string _pants;
    [RealtimeProperty(4, true, true)]
    private string _shoes;
    [RealtimeProperty(5, true, true)]
    private string _extras;
    #endregion

    #region Movements
    [RealtimeProperty(6, true, true)]
    private bool _grounded;
    [RealtimeProperty(7, true, true)]
    private float _speed;
    [RealtimeProperty(8, true, true)]
    private float _motionSpeed;
    [RealtimeProperty(9, true, true)]
    private bool _jump;
    [RealtimeProperty(10, true, true)]
    private bool _freeFall;
    #endregion
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class ModelSync : RealtimeModel {
    public string shirts {
        get {
            return _shirtsProperty.value;
        }
        set {
            if (_shirtsProperty.value == value) return;
            _shirtsProperty.value = value;
            InvalidateReliableLength();
            FireShirtsDidChange(value);
        }
    }
    
    public string heads {
        get {
            return _headsProperty.value;
        }
        set {
            if (_headsProperty.value == value) return;
            _headsProperty.value = value;
            InvalidateReliableLength();
            FireHeadsDidChange(value);
        }
    }
    
    public string pants {
        get {
            return _pantsProperty.value;
        }
        set {
            if (_pantsProperty.value == value) return;
            _pantsProperty.value = value;
            InvalidateReliableLength();
            FirePantsDidChange(value);
        }
    }
    
    public string shoes {
        get {
            return _shoesProperty.value;
        }
        set {
            if (_shoesProperty.value == value) return;
            _shoesProperty.value = value;
            InvalidateReliableLength();
            FireShoesDidChange(value);
        }
    }
    
    public string extras {
        get {
            return _extrasProperty.value;
        }
        set {
            if (_extrasProperty.value == value) return;
            _extrasProperty.value = value;
            InvalidateReliableLength();
            FireExtrasDidChange(value);
        }
    }
    
    public bool grounded {
        get {
            return _groundedProperty.value;
        }
        set {
            if (_groundedProperty.value == value) return;
            _groundedProperty.value = value;
            InvalidateReliableLength();
            FireGroundedDidChange(value);
        }
    }
    
    public float speed {
        get {
            return _speedProperty.value;
        }
        set {
            if (_speedProperty.value == value) return;
            _speedProperty.value = value;
            InvalidateReliableLength();
            FireSpeedDidChange(value);
        }
    }
    
    public float motionSpeed {
        get {
            return _motionSpeedProperty.value;
        }
        set {
            if (_motionSpeedProperty.value == value) return;
            _motionSpeedProperty.value = value;
            InvalidateReliableLength();
            FireMotionSpeedDidChange(value);
        }
    }
    
    public bool jump {
        get {
            return _jumpProperty.value;
        }
        set {
            if (_jumpProperty.value == value) return;
            _jumpProperty.value = value;
            InvalidateReliableLength();
            FireJumpDidChange(value);
        }
    }
    
    public bool freeFall {
        get {
            return _freeFallProperty.value;
        }
        set {
            if (_freeFallProperty.value == value) return;
            _freeFallProperty.value = value;
            InvalidateReliableLength();
            FireFreeFallDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(ModelSync model, T value);
    public event PropertyChangedHandler<string> shirtsDidChange;
    public event PropertyChangedHandler<string> headsDidChange;
    public event PropertyChangedHandler<string> pantsDidChange;
    public event PropertyChangedHandler<string> shoesDidChange;
    public event PropertyChangedHandler<string> extrasDidChange;
    public event PropertyChangedHandler<bool> groundedDidChange;
    public event PropertyChangedHandler<float> speedDidChange;
    public event PropertyChangedHandler<float> motionSpeedDidChange;
    public event PropertyChangedHandler<bool> jumpDidChange;
    public event PropertyChangedHandler<bool> freeFallDidChange;
    
    public enum PropertyID : uint {
        Shirts = 1,
        Heads = 2,
        Pants = 3,
        Shoes = 4,
        Extras = 5,
        Grounded = 6,
        Speed = 7,
        MotionSpeed = 8,
        Jump = 9,
        FreeFall = 10,
    }
    
    #region Properties
    
    private ReliableProperty<string> _shirtsProperty;
    
    private ReliableProperty<string> _headsProperty;
    
    private ReliableProperty<string> _pantsProperty;
    
    private ReliableProperty<string> _shoesProperty;
    
    private ReliableProperty<string> _extrasProperty;
    
    private ReliableProperty<bool> _groundedProperty;
    
    private ReliableProperty<float> _speedProperty;
    
    private ReliableProperty<float> _motionSpeedProperty;
    
    private ReliableProperty<bool> _jumpProperty;
    
    private ReliableProperty<bool> _freeFallProperty;
    
    #endregion
    
    public ModelSync() : base(null) {
        _shirtsProperty = new ReliableProperty<string>(1, _shirts);
        _headsProperty = new ReliableProperty<string>(2, _heads);
        _pantsProperty = new ReliableProperty<string>(3, _pants);
        _shoesProperty = new ReliableProperty<string>(4, _shoes);
        _extrasProperty = new ReliableProperty<string>(5, _extras);
        _groundedProperty = new ReliableProperty<bool>(6, _grounded);
        _speedProperty = new ReliableProperty<float>(7, _speed);
        _motionSpeedProperty = new ReliableProperty<float>(8, _motionSpeed);
        _jumpProperty = new ReliableProperty<bool>(9, _jump);
        _freeFallProperty = new ReliableProperty<bool>(10, _freeFall);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _shirtsProperty.UnsubscribeCallback();
        _headsProperty.UnsubscribeCallback();
        _pantsProperty.UnsubscribeCallback();
        _shoesProperty.UnsubscribeCallback();
        _extrasProperty.UnsubscribeCallback();
        _groundedProperty.UnsubscribeCallback();
        _speedProperty.UnsubscribeCallback();
        _motionSpeedProperty.UnsubscribeCallback();
        _jumpProperty.UnsubscribeCallback();
        _freeFallProperty.UnsubscribeCallback();
    }
    
    private void FireShirtsDidChange(string value) {
        try {
            shirtsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireHeadsDidChange(string value) {
        try {
            headsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FirePantsDidChange(string value) {
        try {
            pantsDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireShoesDidChange(string value) {
        try {
            shoesDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireExtrasDidChange(string value) {
        try {
            extrasDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireGroundedDidChange(bool value) {
        try {
            groundedDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireSpeedDidChange(float value) {
        try {
            speedDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireMotionSpeedDidChange(float value) {
        try {
            motionSpeedDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireJumpDidChange(bool value) {
        try {
            jumpDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireFreeFallDidChange(bool value) {
        try {
            freeFallDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _shirtsProperty.WriteLength(context);
        length += _headsProperty.WriteLength(context);
        length += _pantsProperty.WriteLength(context);
        length += _shoesProperty.WriteLength(context);
        length += _extrasProperty.WriteLength(context);
        length += _groundedProperty.WriteLength(context);
        length += _speedProperty.WriteLength(context);
        length += _motionSpeedProperty.WriteLength(context);
        length += _jumpProperty.WriteLength(context);
        length += _freeFallProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _shirtsProperty.Write(stream, context);
        writes |= _headsProperty.Write(stream, context);
        writes |= _pantsProperty.Write(stream, context);
        writes |= _shoesProperty.Write(stream, context);
        writes |= _extrasProperty.Write(stream, context);
        writes |= _groundedProperty.Write(stream, context);
        writes |= _speedProperty.Write(stream, context);
        writes |= _motionSpeedProperty.Write(stream, context);
        writes |= _jumpProperty.Write(stream, context);
        writes |= _freeFallProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.Shirts: {
                    changed = _shirtsProperty.Read(stream, context);
                    if (changed) FireShirtsDidChange(shirts);
                    break;
                }
                case (uint) PropertyID.Heads: {
                    changed = _headsProperty.Read(stream, context);
                    if (changed) FireHeadsDidChange(heads);
                    break;
                }
                case (uint) PropertyID.Pants: {
                    changed = _pantsProperty.Read(stream, context);
                    if (changed) FirePantsDidChange(pants);
                    break;
                }
                case (uint) PropertyID.Shoes: {
                    changed = _shoesProperty.Read(stream, context);
                    if (changed) FireShoesDidChange(shoes);
                    break;
                }
                case (uint) PropertyID.Extras: {
                    changed = _extrasProperty.Read(stream, context);
                    if (changed) FireExtrasDidChange(extras);
                    break;
                }
                case (uint) PropertyID.Grounded: {
                    changed = _groundedProperty.Read(stream, context);
                    if (changed) FireGroundedDidChange(grounded);
                    break;
                }
                case (uint) PropertyID.Speed: {
                    changed = _speedProperty.Read(stream, context);
                    if (changed) FireSpeedDidChange(speed);
                    break;
                }
                case (uint) PropertyID.MotionSpeed: {
                    changed = _motionSpeedProperty.Read(stream, context);
                    if (changed) FireMotionSpeedDidChange(motionSpeed);
                    break;
                }
                case (uint) PropertyID.Jump: {
                    changed = _jumpProperty.Read(stream, context);
                    if (changed) FireJumpDidChange(jump);
                    break;
                }
                case (uint) PropertyID.FreeFall: {
                    changed = _freeFallProperty.Read(stream, context);
                    if (changed) FireFreeFallDidChange(freeFall);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _shirts = shirts;
        _heads = heads;
        _pants = pants;
        _shoes = shoes;
        _extras = extras;
        _grounded = grounded;
        _speed = speed;
        _motionSpeed = motionSpeed;
        _jump = jump;
        _freeFall = freeFall;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
