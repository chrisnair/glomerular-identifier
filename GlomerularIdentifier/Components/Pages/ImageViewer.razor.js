let viewer;
export function initializeOpenSeadragon(containerId, options) {
    // @ts-ignore
    viewer  = OpenSeadragon(Object.assign({ id: containerId }, options));

    viewer.addHandler('open', function() {
        // @ts-ignore
        const initialCenter = new OpenSeadragon.Point(options.initialCenterX, options.initialCenterY)
        viewer.viewport.panTo(initialCenter, true);
        viewer.viewport.zoomTo(options.initialZoom);
        viewer.viewport.applyConstraints();
    });
    return viewer;
 }

 export function getViewerCoordinates() {

    if(!viewer) {
        console.error('getViewerPosition called before viewer is initialized');
        return null;
    }

    const center = viewer.viewport.getCenter();
    const zoomLevel = viewer.viewport.getZoom();

    return {
        centerX: center.x,
        centerY: center.y,
        zoomLevel
    };
    
}