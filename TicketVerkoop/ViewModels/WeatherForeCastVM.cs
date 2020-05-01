﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketVerkoop.ViewModels
{
    public partial class Temperatures
    {
        [JsonProperty("consolidated_weather")]
        public ConsolidatedWeather[] ConsolidatedWeather { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("sun_rise")]
        public DateTimeOffset SunRise { get; set; }

        [JsonProperty("sun_set")]
        public DateTimeOffset SunSet { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }

        [JsonProperty("sources")]
        public Source[] Sources { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public long Woeid { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public partial class ConsolidatedWeather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonProperty("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }

        [JsonProperty("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("applicable_date")]
        public DateTimeOffset ApplicableDate { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("the_temp")]
        public double TheTemp { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("wind_direction")]
        public double WindDirection { get; set; }

        [JsonProperty("air_pressure")]
        public double AirPressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("predictability")]
        public long Predictability { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public long Woeid { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("crawl_rate")]
        public long CrawlRate { get; set; }
    }
}
