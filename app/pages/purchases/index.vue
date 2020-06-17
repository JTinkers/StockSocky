<template>
	<v-container fluid>
		<v-row justify='end'>
			<v-col cols='4'>
				<v-text-field v-model='search' outlined placeholder='Search..'/>
			</v-col>
		</v-row>
		<v-row>
			<v-col cols='12'>
				<ItemDialog ref='dialog'/>
				<v-data-table hide-default-footer :search='search' :items='purchases' :headers='headers'>
					<template #item.actions='{ item }'>
						<v-icon v-text='"mdi-lead-pencil"' @click='edit(item)'/>
						<v-icon v-text='"mdi-delete"' @click='remove(item)'/>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
		<v-row justify='end'>
			<v-col cols='auto'>
				<v-btn outlined v-text='"Add"' @click='$refs.dialog.open()'/>
			</v-col>
		</v-row>
	</v-container>
</template>

<script>
	import ItemDialog from './partials/ItemDialog'

	export default
	{
		components: { ItemDialog },
		data: () =>
		({
			search: null
		}),
		computed:
		{
			purchases()
			{
				return this.$store.state.purchases.items
			},
			headers()
			{
				var headers =
				[
					{
						text: 'Stock - Symbol',
						value: 'stock.symbol'
					},
					{
						text: 'Stock - Name',
						value: 'stock.name'
					},
					{
						text: 'Quantity',
						value: 'quantity'
					},
					{
						text: 'Value',
						value: 'value'
					},
					{
						text: 'Total',
						value: 'total'
					},
					{
						text: 'Actions',
						value: 'actions',
						align: 'center'
					}
				]

				return headers
			}
		},
		methods:
		{
			edit(purchase)
			{
				this.$refs.dialog.open(Object.assign({}, purchase))
			},
			remove(purchase)
			{
				this.$store.dispatch('purchases/delete', purchase)
			}
		}
	}
</script>
