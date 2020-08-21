# AutoAutoRotate
### Dead simple image auto-rotation for Umbraco v8+

Many images, especially those produced by mobile devices, are landscape in terms of actual pixel data but have their orientation set by EXIF data. Generally speaking this is a good thing, but the default configuration for ImageProcessor in Umbraco is to strip out the EXIF data and ignore it before resizing. 

A portrait image at full size will look fine in the browser (as the browser reads the EXIF data and knows what to do) but as soon as it's processed by ImageProcessor it get's flipped back round to landscape.

As [ImageProcessor's AutoRotate](https://imageprocessor.org/imageprocessor-web/configuration/#processingconfig) is already enabled by default, to fix it all we need to do is append `&autrotate=true` to the image URL. but that can be a bit of a faff to implement everywhere.

All this package does is intercept requests to ImageProcessor and add `autorotate=true` to every request. 

If the parameter already appears in the querystring, either true or false, then it will not override it.

## Config

`preserveExifMetaData` must be set to `false` and the AutoRotate plugin must be enabled in `/config/imageprocessor/processing.config`. These are the defaults so it should work OOTB.

```
<processing preserveExifMetaData="false" metaDataMode="None" fixGamma="false" interceptAllRequests="false" allowCacheBuster="true">
...
<plugin name="AutoRotate" type="ImageProcessor.Web.Processors.AutoRotate, ImageProcessor.Web" enabled="true" />

```
