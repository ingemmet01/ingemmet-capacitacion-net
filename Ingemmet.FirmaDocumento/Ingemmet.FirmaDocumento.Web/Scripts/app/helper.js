(function ($) {
    var rbracket = /\[\]$/,
        rCRLF = /\r?\n/g,
        rsubmitterTypes = /^(?:submit|button|image|reset|file)$/i,
        rsubmittable = /^(?:input|select|textarea|keygen)/i,
        rcheckableType = /^(?:checkbox|radio)$/i;

    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    /**
     * Serializa los controles de un formulario en un Object
     * @param {Bolean} includesDisabled - Incluye inputs desabilitados por defectos es true.
     * @example
     * HTML---------------------------------------------------------------------------------
     * <form>
     *   <input type="text" name="input"/>
     *   <input type="text" data-attr-name="input"/> 
     * </form>
     * JavaScript---------------------------------------------------------------------------
     * $('form').customSerializeArray();
     * @return {Object} 
     * [{name:value, value:value},{name:value, value:value},...]
    **/
    $.fn.customSerializeArray = function (includesDisabled = true) {
        return this.map(function () {

            // Can add propHook for 'elements' to filter or add form elements
            var elements = $.prop(this, 'elements');
            return elements ? $.makeArray(elements) : this;
        })
            .filter(function () {
                var type = this.type;

                // Use .is(':disabled') so that fieldset[disabled] works
                return this.name && (includesDisabled ? true : !$(this).is(':disabled')) &&
                    rsubmittable.test(this.nodeName) && !rsubmitterTypes.test(type) &&
                    (this.checked || !rcheckableType.test(type));
            })
            .map(function (i, elem) {
                var val = $(this).val(), attrName = $(this).attr('data-attr-name');

                if (val === null)
                    return null;

                if ($.isArray(val)) {
                    return $.map(val, function (val) {
                        return { name: attrName !== undefined ? attrName : elem.name, value: val.replace(rCRLF, '\r\n') };
                    });
                }

                return { name: attrName !== undefined ? attrName : elem.name, value: val.replace(rCRLF, '\r\n') };
            }).get();
    };

    /**
     * Serializa los controles de un formulario en un Object
     * @see {@link $.fn.customSerializeArray}
     * @param {Bolean} includesDisabled - Incluye inputs desabilitados por defectos es true.
     * @example
     * HTML--------------------------------------------------
     * <form>
     *   <input type="text" name="input"/>
     *   <input type="text" data-attr-name="input"/> 
     * </form>
     * JavaScript--------------------------------------------
     * $('form').customSerializeObject();
     * @return {Object} 
     * {input1:valor,input2:valor,...}
    **/
    $.fn.customSerializeObject = function (includesDisabled = true) {
        var o = {};
        var a = this.customSerializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    $.fn.serealizeInput = function () {
        var input = this.serializeArray();
        if (input.length > 0)
            return input[0].value;
        return "";
    };

    $.beforeunload = function (estado) {
        estado = (estado === undefined || estado === true) ? true : false;
        if (estado) {
            $(window).on('beforeunload', function (e) {
                e = e || window.event;
                e.preventDefault = true;
                e.cancelBubble = true;
                return "¿Está seguro de realizar esta operación?";
            });
        } else {
            $(window).off('beforeunload');
        }
    };

    $.fn.blink = function (interval, iterate) {
        interval = interval || 100;
        iterate = iterate || 1;
        for (var i = 1; i <= iterate; i++)
            $(this).fadeOut(interval).fadeIn(interval);
    };

})(jQuery);