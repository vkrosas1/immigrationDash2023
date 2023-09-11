import TreeView from "./TreeView";

function HomeController(props) {

    console.log(props)

    // Planning on one tree view per parent path
    return props.isLoading ? "Oops" : <TreeView {...props} />;
}

export default HomeController;