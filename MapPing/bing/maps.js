function GetMap() {

    var map = new Microsoft.Maps.Map('#myMap', {
        credentials: 'Asw_TeEjyx-dz1wmVZH9sgui2TXhJdm5NlEqmsDLPCJyyY84L9LnOkycw1YIbitO',
        //center: new Microsoft.Maps.Location(53.592, -7.832),
        //mapTypeId: Microsoft.Maps.MapTypeId.aerial,
        //zoom:7
    });

    //Load the Animation Module
    //Microsoft.Maps.loadModule("AnimationModule");

    var viewBoundaries = Microsoft.Maps.LocationRect.fromLocations(
        new Microsoft.Maps.Location(55.418594, -6.347618),
        new Microsoft.Maps.Location(52.318594, -6.347618),
        new Microsoft.Maps.Location(52.318594, -10.347618));

    map.setView({ bounds: viewBoundaries });

    var center = map.getCenter();

    //Create custom Pushpin using an HTML5 canvas.
    var pin = new Microsoft.Maps.Pushpin(center, {
        icon: drawCircle(),
        anchor: new Microsoft.Maps.Point(12, 12)
    });

    //Add the pushpin to the map
    map.entities.push(pin);

    var pin2 = new Microsoft.Maps.Pushpin(map.getCenter(), {
        //icon: "<div class='scaleStyle'>Custom Pushpin</div>",
        title: 'Ireland',
        subTitle: 'center',
        text: '1',

        //height: 20,
        //width:20,
        //draggable: true
    });

    //map.entities.push(pin2);
}

function drawCircle()
{
    var canvas = document.createElement('canvas');

    var ctx = canvas.getContext('2d');
    ctx.fillStyle = '#f00';
    ctx.beginPath();
    ctx.arc(100, 75, 30, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    return canvas.toDataURL();
}

var requestAnimationFrame = window.requestAnimationFrame ||
                            window.mozRequestAnimationFrame ||
                            window.webkitRequestAnimationFrame ||
                            window.msRequestAnimationFrame;

function animate(circle, canvas, context, startTime)
{

}

function createRedArrow(heading) {
    var c = document.createElement('canvas');
    c.width = 24;
    c.height = 24;

    var ctx = c.getContext('2d');

    //Offset the canvas such that we will rotate around the center of our arrow
    ctx.translate(c.width * 0.5, c.height * 0.5);

    //Rotate the canvas by the desired heading
    ctx.rotate(heading * Math.PI / 180);

    //Return the canvas offset back to it's original position
    ctx.translate(-c.width * 0.5, -c.height * 0.5);

    ctx.fillStyle = '#f00';

    //Draw a path in the shape of an arrow.
    ctx.beginPath();
    ctx.moveTo(12, 0);
    ctx.lineTo(5, 20);
    ctx.lineTo(12, 15);
    ctx.lineTo(19, 20);
    ctx.lineTo(12, 0);
    ctx.closePath();
    ctx.fill();
    ctx.stroke();

    //Generate the base64 image URL from the canvas.
    return c.toDataURL();
}