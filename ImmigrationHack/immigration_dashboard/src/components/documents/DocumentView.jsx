import { STATUSES } from "../../Constants"

function DocumentsList(props) {

    const generateOnClick = function (documentForm) {
        return (event) => {
            props.onDocumentSelect(documentForm)
        }
    }

    const generateTiles = (data) => {
        return data.map((doc, index) => {
            doc.status = doc.status || STATUSES.NOT_STARTED.key;
            return (
                <div key={index} onClick={generateOnClick(doc)} class="column is-2">
                    <div class={`card p-2 has-background-${STATUSES[doc.status].className}`}>{doc.id}</div>
                </div>
            )
        })
    }

    return (
        <div class="container columns is-multiline is-vcentered">
            {generateTiles(props.documentForms)}
        </div>
    );
}

export default DocumentsList;