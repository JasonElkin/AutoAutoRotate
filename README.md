# AutoAutoRotate
### Dead simple image auto-rotation for Umbraco v8+

Automatically runs ImageProcessor's AutoRotate, for fire-and-forget mobile image uploads.

![Before and after](https://github.com/JasonElkin/AutoAutoRotate/raw/main/images/Example.jpg)

Many images, especially those produced by mobile devices, are landscape in terms of actual pixel data but have their orientation set by EXIF data. Generally speaking this is a good thing, but the default configuration for ImageProcessor in Umbraco is to strip out the EXIF data and ignore it before resizing. 

A portrait image at full size will look fine in the browser (the browser reads the EXIF data and knows what to do) but once it's processed by ImageProcessor it gets flipped back round to landscape.

As [ImageProcessor's AutoRotate](https://imageprocessor.org/imageprocessor-web/configuration/#processingconfig) is already enabled by default, to fix it all we need to do is append `&autrotate=true` to the image URL. but that can be a bit of a faff to implement everywhere.

All this package does is hook into ImageProcessor's vaidation event add `autorotate=true` to every request. 

If the parameter already appears in the querystring, either true or false, then it will not override it.

## Config

`preserveExifMetaData` must be set to `false` and the AutoRotate plugin must be enabled in `/config/imageprocessor/processing.config`. These are the defaults so it should work OOTB.

```
<processing preserveExifMetaData="false" metaDataMode="None" fixGamma="false" interceptAllRequests="false" allowCacheBuster="true">
...
<plugin name="AutoRotate" type="ImageProcessor.Web.Processors.AutoRotate, ImageProcessor.Web" enabled="true" />

```
## Caching

### Browser caching could be a problem
You didn't actually leave images published the wrong way up on the website like that... did you...?

The querystring itself is not modified so browsers that have cached the incorrectly rotated images will keep seeing them until their cache is cleared. Clearing your cache will fix this for you (and for the backoffice) but you'll need to take manual steps to change the image URL to fix this issue for any other previous visitors.

### ImageProcessor caching will not be
As far as ImageProcessor is concerned the querystring _has_ changed so it will re-process the image and cache the new one.