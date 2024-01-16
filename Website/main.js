const apiUrl = "https://toolsfu.azurewebsites.net/api/Tools/";

const app = Vue.createApp({
    data()
    {
        return {
            // Get data
            toolsList: [],
            
            // Get by id
            inputToolId: "",
            tool: null,

            // Add data
            addedTool: null,
            newTool: { type: '', price: ''},

            // Update data
            idToUpdate: '',
            ifUpdatedTool: null,
            updatedTool: { type: '', price: ''}
               };
    },
    methods:
    {
        async fetchTools()
        {
            try 
            {
                const response = await axios.get(apiUrl);
                console.log('Response data', response.data);
                this.toolsList = response.data;

            }
            catch (error)
            {
                console.error('Error fetching Tools', error);
            }
        },
        async fetchToolById() 
        {
            try 
            {
                const response = await axios.get(apiUrl + this.inputToolId);
                this.tool = response.data;
            }
            catch (error)
            {
                console.error('Error fetching tool', error);
                this.tool = null;

            }
        },
        async addTool()
        {
            try
            {
                const response = await axios.post(apiUrl, this.newTool);
                this.addedTool = response.data;

                this.toolsList.push(response.data); // Updates list without having to refresh site with F5

            }
            catch (error)
            {
                console.error('Error adding tool', error);

            }
        },
        async updateTool()
        {
            try
            {
                const response = await axios.put(`${apiUrl}/${this.idToUpdate}`, this.updatedTool);
               
                this.ifUpdatedTool = response.data;
                console.log('Tool updated successfully', response.data);
            }
            catch (error)
            {
                console.error('Error updating tool', error);
            }
        }
    },
    mounted()
    {
        this.fetchTools(); // Call fetchTools when component is mounted

    }
});

// Mount app
app.mount("#app");