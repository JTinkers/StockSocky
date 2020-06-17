<template>
	<v-dialog width='600' v-model='show'>
		<v-card>
			<v-card-title>
				<span class='headline' v-text='"Stock"'/>
			</v-card-title>
			<v-form ref='form'>
				<v-container>
					<v-row>
						<v-col cols='12'>
							<v-select outlined :disabled='item.id' :items='stocks' item-value='id' :item-text='(item) => item.symbol + " - " + item.name' label='Stock' v-model='item.stockId'/>
						</v-col>
					</v-row>
					<v-row>
						<v-col cols='6'>
							<v-text-field outlined label='Quantity' type='number' v-model='item.quantity'/>
						</v-col>
						<v-col cols='6'>
							<v-text-field outlined label='Value (per piece)' type='number' v-model='item.value'/>
						</v-col>
					</v-row>
				</v-container>
			</v-form>
			<v-card-actions>
				<v-container>
					<v-row justify='end'>
						<v-btn text v-text='"Save"' @click='save'/>
						<v-btn text v-text='"Cancel"' @click='cancel'/>
					</v-row>
				</v-container>
			</v-card-actions>
		</v-card>
	</v-dialog>
</template>

<script>
	export default
	{
		data: () =>
		({
			show: false,
			item: {},
			stocks: []
		}),
		async mounted()
		{
			var { data } = await this.$axios.get('/api/stocks')

			this.stocks = data
		},
		methods:
		{
			open(values)
			{
				this.$set(this, 'item', values || {})

				this.show = true
			},
			async save()
			{
				// update else add
				if(this.item.id)
					await this.$axios.put('/api/purchases/' + this.item.id, this.item)
				else
					await this.$axios.post('/api/purchases', this.item)

				this.cancel()
			},
			cancel()
			{
				this.$set(this, 'item', {})

				this.show = false
			}
		}
	}
</script>
