define(function (require) {

    var List = require('../../data/List');
    var echarts = require('../../echarts');
    var SeriesModel = require('../../model/Series');
    var zrUtil = require('zrender/core/util');
    var completeDimensions = require('../../data/helper/completeDimensions');

    var formatUtil = require('../../util/format');
    var encodeHTML = formatUtil.encodeHTML;
    var addCommas = formatUtil.addCommas;

    var dataSelectableMixin = require('../helper/dataSelectableMixin');

    function fillData(dataOpt, geoJson) {
        var dataNameMap = {};
        var features = geoJson.features;
        for (var i = 0; i < dataOpt.length; i++) {
            dataNameMap[dataOpt[i].name] = dataOpt[i];
        }

        for (var i = 0; i < features.length; i++) {
            var name = features[i].properties.name;
            if (!dataNameMap[name]) {
                dataOpt.push({
                    value: NaN,
                    name: name
                });
            }
        }
        return dataOpt;
    }

    var MapSeries = SeriesModel.extend({

        type: 'series.map',

        /**
         * Only first map series of same mapType will drawMap
         * @type {boolean}
         */
        needsDrawMap: false,

        /**
         * Group of all map series with same mapType
         * @type {boolean}
         */
        seriesGroup: [],

        init: function (option) {

            option = this._fillOption(option);
            this.option = option;

            MapSeries.superApply(this, 'init', arguments);

            this.updateSelectedMap();
        },

        getInitialData: function (option) {
            var dimensions = completeDimensions(['value'], option.data || []);

            var list = new List(dimensions, this);

            list.initData(option.data);

            return list;
        },

        mergeOption: function (newOption) {
            newOption = this._fillOption(newOption);

            MapSeries.superCall(this, 'mergeOption', newOption);

            this.updateSelectedMap();
        },

        _fillOption: function (option) {
            // Shallow clone
            option = zrUtil.extend({}, option);

            var map = echarts.getMap(option.map);
            var geoJson = map && map.geoJson;
            geoJson && option.data
                && (option.data = fillData(option.data, geoJson));

            return option;
        },

        /**
         * @param {number} zoom
         */
        setRoamZoom: function (zoom) {
            var roamDetail = this.option.roamDetail;
            roamDetail && (roamDetail.zoom = zoom);
        },

        /**
         * @param {number} x
         * @param {number} y
         */
        setRoamPan: function (x, y) {
            var roamDetail = this.option.roamDetail;
            if (roamDetail) {
                roamDetail.x = x;
                roamDetail.y = y;
            }
        },

        getRawValue: function (dataIndex) {
            // Use value stored in data instead because it is calculated from multiple series
            // FIXME Provide all value of multiple series ?
            return this._data.get('value', dataIndex);
        },

        /**
         * Map tooltip formatter
         *
         * @param {number} dataIndex
         */
        formatTooltip: function (dataIndex) {
            var data = this._data;
            var formattedValue = addCommas(this.getRawValue(dataIndex));
            var name = data.getName(dataIndex);

            var seriesGroup = this.seriesGroup;
            var seriesNames = [];
            for (var i = 0; i < seriesGroup.length; i++) {
                if (!isNaN(seriesGroup[i].getRawValue(dataIndex))) {
                    seriesNames.push(
                        encodeHTML(seriesGroup[i].name)
                    );
                }
            }

            return seriesNames.join(', ') + '<br />'
                + name + ' : ' + formattedValue;
        },

        defaultOption: {
            // ????????????
            zlevel: 0,
            // ????????????
            z: 2,
            coordinateSystem: 'geo',
            // ????????? map ??????????????????
            map: 'china',

            // 'center' | 'left' | 'right' | 'x%' | {number}
            left: 'center',
            // 'center' | 'top' | 'bottom' | 'x%' | {number}
            top: 'center',
            // right
            // bottom
            // width:
            // height   // ?????????

            // ????????????????????????????????????????????????
            // 'sum' | 'average' | 'max' | 'min'
            // mapValueCalculation: 'sum',
            // ????????????????????????????????????
            // mapValuePrecision: 0,
            // ??????????????????????????????????????????????????????????????????????????????
            showLegendSymbol: true,
            // ????????????????????????????????????single???multiple
            // selectedMode: false,
            dataRangeHoverLink: true,
            // ?????????????????????????????????
            // roam: false,

            // ??? roam ?????????????????????
            roamDetail: {
                x: 0,
                y: 0,
                zoom: 1
            },

            scaleLimit: null,

            label: {
                normal: {
                    show: false,
                    textStyle: {
                        color: '#000'
                    }
                },
                emphasis: {
                    show: false,
                    textStyle: {
                        color: '#000'
                    }
                }
            },
            // scaleLimit: null,
            itemStyle: {
                normal: {
                    // color: ??????,
                    borderWidth: 0.5,
                    borderColor: '#444',
                    areaColor: '#eee'
                },
                // ??????????????????
                emphasis: {
                    areaColor: 'rgba(255,215, 0, 0.8)'
                }
            }
        }
    });

    zrUtil.mixin(MapSeries, dataSelectableMixin);

    return MapSeries;
});