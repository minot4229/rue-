module BusWire

open Fable.React
open Fable.React.Props
open Browser
open Elmish
open Elmish.React
open Helpers


//------------------------------------------------------------------------//
//------------------------------BusWire Types-----------------------------//
//------------------------------------------------------------------------//
type Wire = {
    Id: ConnectionId
    SrcPort: InputPortId 
    TargetPort: OutputPortId
    IsError: bool
    BoundingBoxes: BoundingBox list
}


type Model = {
    WX: Wire list
    Symbol: Symbol list
    Color: HighlightColor
}


//----------------------------Message Type-----------------------------------//
type Msg = 
    | CreateConnection of Wire.SrcPort * Wire.TargetPort
    | SelectWires of CommonTypes.ConnectionId
    | DeleteWires of CommonTypes.ConnectionId
    | SetColor of CommonTypes.HighLightColor


/// look up wire in WireModel
let wireTryfind (wModel: Model) (wId: CommonTypes.ConnectionId): Wire =
    wModel.WX 
    |> List.tryFind (fun wireInList -> wireInList.Id=wId) 
    |> wireTryfind //<-----

type WireRenderProps = {
    key : CommonTypes.ConnectionId
    WireP: Wire
    SrcP: XYPos     
    TgtP: XYPos
    ColorP: string
    StrokeWidthP: string }


/// react virtual DOM SVG for one wire
/// In general one wire will be multiple (right-angled) segments.
let singleWireView = 
    FunctionComponent.Of(
        fun (props: WireRenderProps) ->
            line [
                X1 props.SrcP.X
                Y1 props.SrcP.Y
                X2 props.TgtP.X
                Y2 props.TgtP.Y
                // Qualify these props to avoid name collision with CSSProp
                SVGAttr.Stroke props.ColorP
                SVGAttr.StrokeWidth props.StrokeWidthP ] [])

let view (modelView:Model) (dispatch: Dispatch<Msg>) =
    let //<---------------------


///initial state of the BusWire
let initi n () = {
    let WX = []
    let Symbol = []
    let Color = CommonTypes.Black
    } 

let update (message: Msg) (modeling:Model): Model*Cmd<Msg> = 
    match message with =
    | CreateConnection ->      //of Wire.SrcPort * Wire.TargetPort
        此处放置创造连接的方程->
         

    | SelectWires ->           //of CommonTypes.ConnectionId


    | DeleteWires ->           //of CommonTypes.ConnectionId


    | SetColor c>              //of CommonTypes.HighLightColor
        {modeling with Color = c}, Cmd.none

